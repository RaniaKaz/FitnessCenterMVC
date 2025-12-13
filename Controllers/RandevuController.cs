using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using webProject.Data;
using webProject.Models;

namespace webProject.Controllers
{
    public class RandevuController : Controller
    {
        private readonly FitnessDbContext _context;
        public RandevuController(FitnessDbContext context)
        {
            _context = context;
        }
        private List<Antrenor> uygunAntrenorleriGetir(int hizmetid, DateTime baslangic, int sure)
        {
            //Başlangıç zamanına, verilen dakika süresini ekleyip
            //bitiş zamanını hesaplıyor.
            var bitis = baslangic.AddMinutes(sure);
            var gun = baslangic.DayOfWeek; //haftanın hangni günü

            return _context.Antrenor
                //Antrenörlerin verilen hizmeti sunup sunmadığını kontrol et
                .Where(a => a.AntHizmetler.Any(ah => ah.HizID == hizmetid))
                //Antrenörlerin müsaitlik durumunu kontrol et
                .Where(a => a.Musaitlik.Any(m => m.Gun == gun &&
                m.BaslangicTarihi == baslangic && m.BitisAraligi == bitis.TimeOfDay))
                //Saat çakışması var mı
                .Where(a => !a.Randevular.Any(r => baslangic < r.RandevuTarihi && bitis > r.RandevuTarihi))
                .ToList();
        }
        //-----Create İşlemi-----
        public IActionResult RanOlustur()
        {
            ViewData["Uyeler"] = new SelectList(_context.Uye, "ID", "Ad"); //HTML'de option
            ViewData["Hizmetler"] = new SelectList(_context.Hizmet, "ID", "HizmetAd");
            return View();
        }
        [HttpPost]
        public IActionResult RanOlustur(int uyeID, int hizmetId, DateTime BaslangicTarihi)
        {
            var hizmet = _context.Hizmet.FirstOrDefault(h => h.ID == hizmetId);
            if (hizmet == null)
                return NotFound();

            var uygunAntrenoler = uygunAntrenorleriGetir(hizmetId, BaslangicTarihi, hizmet.SureDaikia);

            if (!uygunAntrenoler.Any())
            {
                ViewData["Bulunamadi"] = "Seçilen zaman diliminde uygun antrenör bulunamadı.";
                return View();
            }

            var antrenor = uygunAntrenoler.First();

            var randevu = new Randevu
            {
                UyeID = uyeID,
                HizmetID = hizmetId,
                AtrenorID = antrenor.ID,
                RandevuTarihi = BaslangicTarihi,
                sureDk = hizmet.SureDaikia,
                OnayDurumu = false

            };

            _context.Randevu.Add(randevu);
            _context.SaveChanges();
            return RedirectToAction("RanList");


            /*if (ModelState.IsValid)
            {
                _context.Randevu.Add(randevu);
                _context.SaveChanges();
                return RedirectToAction("RanList");
            }
            return View("RanOlustur");*/
        }
        //-----Detay İşlemi-----
        public IActionResult RanDetay(int id)
        {
            if (id <= 0)
                return NotFound();

            var randevu = _context.Randevu.FirstOrDefault(r => r.ID == id);

            if (randevu == null)
                return NotFound();

            return View(randevu);
        }
        //-----Düzenleme İşlemi-----
        public IActionResult RanDuzenle(int id)
        {
            if (id <= 0)
                return NotFound();

            var randevu = _context.Randevu.FirstOrDefault(r => r.ID == id);
            if (randevu == null)
                return NotFound();
            return View(randevu);
        }
        [HttpPost]
        public IActionResult RanDuzenle(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                _context.Randevu.Update(randevu);
                _context.SaveChanges();
                return RedirectToAction("RanList");
            }
            return View(randevu);
        }
        //-----Listeleme İşlemi-----
        public IActionResult RanList()
        {
            var randevular = _context.Randevu.ToList();
            return View(randevular);
        }

        //-----Delete İşlemi-----
        public IActionResult RanSil(int id)
        {
            if (id <= 0)
                return NotFound();

            var randevu = _context.Randevu.FirstOrDefault(r => r.ID == id);

            if (randevu == null)
                return NotFound();

            return View(randevu);
        }
        [HttpPost]
        public IActionResult RanSilOnay(int id)
        {
            var randevu = _context.Randevu.FirstOrDefault(r => r.ID == id);

            if (randevu == null)
                return NotFound();

            _context.Randevu.Remove(randevu);
            _context.SaveChanges();

            return RedirectToAction("RanList");

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
