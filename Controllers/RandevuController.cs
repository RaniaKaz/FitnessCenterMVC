using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webProject.Data;
using webProject.Models;

namespace webProject.Controllers
{
    [Authorize]
    public class RandevuController : Controller
    {
        private readonly FitnessDbContext _context;
        private readonly UserManager<ApplicationUsers> _userManager;

        public RandevuController(FitnessDbContext context, UserManager<ApplicationUsers> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // ===================== AJAX =====================

        [HttpGet]
        public IActionResult HizmetleriGetir(int salonId)
        {
            var hizmetler = _context.HizSalon
                .Where(x => x.SalonID == salonId)
                .Include(x => x.Hizmet)
                .Select(x => new { id = x.Hizmet.ID, ad = x.Hizmet.Ad })
                .Distinct()
                .ToList();

            return Json(hizmetler);
        }

        [HttpGet]
        public IActionResult AntrenorleriGetir(int hizmetId)
        {
            var antrenorler = _context.AntHizmet
                .Where(x => x.HizmetID == hizmetId)
                .Include(x => x.Antrenor)
                .Select(x => new
                {
                    id = x.Antrenor.ID,
                    ad = x.Antrenor.Ad + " " + x.Antrenor.Soyad
                })
                .Distinct()
                .ToList();

            return Json(antrenorler);
        }
        [HttpGet]
        public IActionResult AntrenorMusaitlikGetir(int antrenorId)
        {
            var musaitlikler = _context.AntMusaitlik
                .Where(m => m.AntrenorID == antrenorId)
                .Select(m => new
                {
                    gun = m.Gun.ToString(),          // Pazartesi, Salı...
                    baslangic = m.Baslangic.ToString(@"hh\:mm"),
                    bitis = m.Bitis.ToString(@"hh\:mm")
                })
                .ToList();

            return Json(musaitlikler);
        }

        // ===================== GET =====================

        [Authorize(Roles = "Uye")]
        public IActionResult RanOlustur()
        {
            var model = new RandevuOlusturViewModel
            {
                Salonlar = _context.Salon
                    .Select(s => new SelectListItem
                    {
                        Value = s.ID.ToString(),
                        Text = s.Ad
                    }).ToList()
            };

            return View(model);
        }

        // ===================== POST =====================

        [Authorize(Roles = "Uye")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RanOlustur(RandevuOlusturViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model.Salonlar = _context.Salon
                    .Select(s => new SelectListItem
                    {
                        Value = s.ID.ToString(),
                        Text = s.Ad
                    }).ToList();

                return View(model);
            }

            var identityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var uye = _context.Uye.FirstOrDefault(u => u.IdentityUserId == identityId);

            if (uye == null)
                return Unauthorized();

            var hizSalon = _context.HizSalon
                .FirstOrDefault(x => x.HizmetID == model.HizmetId && x.SalonID == model.SalonId);

            if (hizSalon == null)
            {
                ModelState.AddModelError("", "Bu hizmet bu salonda yok.");
                return View(model);
            }

            var antrenor = _context.Antrenor.FirstOrDefault(a => a.ID == model.AntrenorId);
            if (antrenor == null)
            {
                ModelState.AddModelError("", "Antrenör bulunamadı.");
                return View(model);
            }

            var randevuTarihi = model.BaslangicTarihi;
            var gun = randevuTarihi.DayOfWeek;
            var saat = randevuTarihi.TimeOfDay;
            // 1️ MÜSAİTLİK KONTROLÜ
            var musaitMi = _context.AntMusaitlik.Any(m =>
                m.AntrenorID == model.AntrenorId &&
                m.Gun == gun &&
                m.Baslangic <= saat &&
                m.Bitis >= saat
            );

            if (!musaitMi)
            {
                ModelState.AddModelError("", "Seçilen saat antrenörün müsait saatleri dışında.");

                model.Salonlar = _context.Salon
                    .Select(s => new SelectListItem
                    {
                        Value = s.ID.ToString(),
                        Text = s.Ad
                    }).ToList();

                return View(model);
            }

            // ÇAKIŞAN RANDEVU VAR MI?
            var cakismaVarMi = _context.Randevu.Any(r =>
                r.AntrenorID == model.AntrenorId &&
                r.RandevuTarihi == randevuTarihi
            );

            if (cakismaVarMi)
            {
                ModelState.AddModelError("", "Bu saat için antrenörün başka bir randevusu var.");

                model.Salonlar = _context.Salon
                    .Select(s => new SelectListItem
                    {
                        Value = s.ID.ToString(),
                        Text = s.Ad
                    }).ToList();

                return View(model);
            }
            var randevu = new Randevu
            {
                UyeID = uye.ID,
                HizmetID = model.HizmetId,
                AntrenorID = model.AntrenorId,
                RandevuTarihi = DateTime.SpecifyKind(model.BaslangicTarihi, DateTimeKind.Utc),
                OnayDurumu = false,
                Ucret = hizSalon.Fiyat
            };

            _context.Randevu.Add(randevu);
            _context.SaveChanges();

            return RedirectToAction("RanList");
        }

        // ===================== LIST =====================

        [Authorize(Roles = "Uye")]
        public async Task<IActionResult> RanList()
        {
            var identityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (identityId == null)
                return Unauthorized();

            var uye = await _context.Uye
                .FirstOrDefaultAsync(u => u.IdentityUserId == identityId);

            if (uye == null)
                return Unauthorized();

            var randevular = await _context.Randevu
                .Include(r => r.Hizmet)
                .Include(r => r.Antrenor)
                .Where(r => r.UyeID == uye.ID)
                .OrderByDescending(r => r.RandevuTarihi)
                .ToListAsync();

            return View(randevular);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AdminRanList()
        {
            var randevular = _context.Randevu
                .Include(r => r.Uye)
                .Include(r => r.Hizmet)
                .Include(r => r.Antrenor)
                .ToList();

            return View(randevular);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult OnayDegistir(int id, bool onay)
        {
            var randevu = _context.Randevu.FirstOrDefault(r => r.ID == id);
            if (randevu == null) return NotFound();

            randevu.OnayDurumu = onay;
            _context.SaveChanges();

            return RedirectToAction("AdminRanList");
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}
