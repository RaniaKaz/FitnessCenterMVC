using Microsoft.AspNetCore.Mvc;
using webProject.Data;
using webProject.Models;

namespace webProject.Controllers
{
    public class HizmetController : Controller
    {
        private readonly FitnessDbContext _context;
        public HizmetController(FitnessDbContext context)
        {
            _context = context;
        }

        //-----Create İşlemi-----
        public IActionResult HizOlustur()
        {

            return View();
        }

        public IActionResult HizEkle(Hizmet hizmet)
        {
            if (ModelState.IsValid)
            {
                _context.Hizmet.Add(hizmet);
                _context.SaveChanges();
                return RedirectToAction("HizList");
            }
            return View("HizOlustur");
        }
        //-----Detay İşlemi-----
        public IActionResult HizDetay(int id)
        {
            if (id <= 0)
                return NotFound();

            var hizmet = _context.Hizmet.FirstOrDefault(h => h.ID == id);

            if (hizmet == null)
                return NotFound();

            return View(hizmet);
        }
        //-----Düzenleme İşlemi-----
        public IActionResult HizDuzenle(int id)
        {
            if (id <= 0)
                return NotFound();

            var hizmet = _context.Hizmet.FirstOrDefault(h => h.ID == id);
            if (hizmet == null)
                return NotFound();
            return View(hizmet);
        }
        [HttpPost]
        public IActionResult HizDuzenle(Hizmet hizmet)
        {
            if (ModelState.IsValid)
            {
                _context.Hizmet.Update(hizmet);
                _context.SaveChanges();
                return RedirectToAction("HizList");
            }
            return View(hizmet);
        }
        //-----Listeleme İşlemi-----
        public IActionResult HizList()
        {
            var hizmetler = _context.Hizmet.ToList();
            return View(hizmetler);
        }

        //-----Delete İşlemi-----
        public IActionResult HizSil(int id)
        {
            if (id <= 0)
                return NotFound();

            var hizmet = _context.Hizmet.FirstOrDefault(h => h.ID == id);

            if (hizmet == null)
                return NotFound();

            return View(hizmet);
        }
        [HttpPost]
        public IActionResult HizSilOnay(int id)
        {
            var hizmet = _context.Hizmet.FirstOrDefault(h => h.ID == id);

            if (hizmet == null)
                return NotFound();

            _context.Hizmet.Remove(hizmet);
            _context.SaveChanges();

            return RedirectToAction("HizList");

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
