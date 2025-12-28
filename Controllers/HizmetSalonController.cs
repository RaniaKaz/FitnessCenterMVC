using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webProject.Data;
using webProject.Models;

namespace webProject.Controllers
{
    [Authorize]
    [Authorize(Roles = "Admin")]
    public class HizmetSalonController : Controller
    {
        private readonly FitnessDbContext _context;

        public HizmetSalonController(FitnessDbContext context)
        {
            _context = context;
        }

        //-----CREATE (GET)-----
        public IActionResult HizSalOlustur()
        {
            ViewData["Salonlar"] = new SelectList(_context.Salon, "ID", "Ad");
            ViewData["Hizmetler"] = new SelectList(_context.Hizmet, "ID", "Ad");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HizSalOlustur(int salonId, int hizmetId, int sure, decimal fiyat)
        {
            // Aynı kayıt var mı?
            bool varMi = _context.HizSalon.Any(x =>
                x.SalonID == salonId &&
                x.HizmetID == hizmetId);

            if (varMi)
            {
                ModelState.AddModelError("", "Bu hizmet bu salonda zaten tanımlı.");
            }

            if (ModelState.IsValid)
            {
                var hizSalon = new HizSalon
                {
                    SalonID = salonId,
                    HizmetID = hizmetId,
                    Sure = sure,
                    Fiyat = fiyat
                };

                _context.HizSalon.Add(hizSalon);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewData["Salonlar"] = new SelectList(_context.Salon, "ID", "Ad");
            ViewData["Hizmetler"] = new SelectList(_context.Hizmet, "ID", "Ad");
            return View();
        }

        //-----DELETE-----
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HizSalSil(int id)
        {
            var hizSalon = _context.HizSalon.FirstOrDefault(x => x.ID == id);
            if (hizSalon == null)
                return NotFound();

            _context.HizSalon.Remove(hizSalon);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        //-----LIST-----
        public IActionResult HizSalList()
        {
            var liste = _context.HizSalon
                .Include(hs => hs.Hizmet)
                .Include(hs => hs.Salon)
                .ToList();

            return View(liste);
        }
        public IActionResult Index()
        {
            var liste = _context.HizSalon
                .Include(hs => hs.Hizmet)
                .Include(hs => hs.Salon)
                .ToList();

            return View(liste);
        }
    }
}
