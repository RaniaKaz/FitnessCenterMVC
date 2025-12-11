using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webProject.Data;
using webProject.Models;

namespace webProject.Controllers
{
    public class SalonController : Controller
    {
        private readonly FitnessDbContext _context;
        public SalonController(FitnessDbContext context)
        {
            _context = context;
        }
        //-----Create İşlemi-----
        public IActionResult SalOlustur()
        {

            return View();
        }

        public IActionResult SalEkle(Salon salon)
        {
            if (ModelState.IsValid)
            {
                _context.Salon.Add(salon);
                _context.SaveChanges();
                return RedirectToAction("SalList");
            }
            return View("SalOlustur");
        }
        //-----Detay İşlemi-----
        public IActionResult SalDetay(int id)
        {
            if (id <= 0)
                return NotFound();

            var salon = _context.Salon.FirstOrDefault(s => s.ID == id);

            if (salon == null)
                return NotFound();

            return View(salon);
        }
        //-----Düzenleme İşlemi-----
        public IActionResult SalDuzenle(int id)
        {
            if (id <= 0)
                return NotFound();

            var salon = _context.Salon.FirstOrDefault(s => s.ID == id);

            return View(salon);
        }
        [HttpPost]
        public IActionResult SalDuzenle(Salon salon)
        {
            if (ModelState.IsValid)
            {
                _context.Salon.Update(salon);
                _context.SaveChanges();
                return RedirectToAction("SalList");
            }
            return View(salon);
        }
        //-----Listeleme İşlemi-----
        public IActionResult SalList()
        {
            var salonlar = _context.Salon.ToList();
            return View(salonlar);
        }

        //-----Delete İşlemi-----
        public IActionResult SalSil(int id)
        {
            if (id <= 0)
                return NotFound();

            var salon = _context.Salon.FirstOrDefault(s => s.ID == id);

            if (salon == null)
                return NotFound();

            return View(salon);
        }
        [HttpPost]
        public IActionResult SalSilOnay(int id)
        {
            var salon = _context.Salon.FirstOrDefault(s => s.ID == id);

            if (salon == null)
                return NotFound();

            _context.Salon.Remove(salon);
            _context.SaveChanges();

            return RedirectToAction("SalList");

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
