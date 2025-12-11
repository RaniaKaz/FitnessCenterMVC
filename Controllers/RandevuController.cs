using Microsoft.AspNetCore.Mvc;
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

        //-----Create İşlemi-----
        public IActionResult RanOlustur()
        {

            return View();
        }

        public IActionResult RanEkle(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                _context.Randevu.Add(randevu);
                _context.SaveChanges();
                return RedirectToAction("RanList");
            }
            return View("RanOlustur");
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
