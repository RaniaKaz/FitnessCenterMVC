using Microsoft.AspNetCore.Mvc;
using webProject.Data;
using webProject.Models;

namespace webProject.Controllers
{
    public class AntrenorController : Controller
    {
        private readonly FitnessDbContext _context;
        public AntrenorController(FitnessDbContext context)
        {
            _context = context;
        }

        //-----Create İşlemi-----
        public IActionResult AntOlustur()
        {

            return View();
        }

        public IActionResult AntEkle(Antrenor antrenor)
        {
            if (ModelState.IsValid)
            {
                _context.Antrenor.Add(antrenor);
                _context.SaveChanges();
                return RedirectToAction("AntList");
            }
            return View("AntOlustur");
        }
        //-----Detay İşlemi-----
        public IActionResult AntDetay(int id)
        {
            if (id <= 0)
                return NotFound();

            var antrenor = _context.Antrenor.FirstOrDefault(a => a.ID == id);

            if (antrenor == null)
                return NotFound();

            return View(antrenor);
        }
        //-----Düzenleme İşlemi-----
        public IActionResult AntDuzenle(int id)
        {
            if (id <= 0)
                return NotFound();

            var antrenor = _context.Antrenor.FirstOrDefault(a => a.ID == id);
            if (antrenor == null)
                return NotFound();
            return View(antrenor);
        }
        [HttpPost]
        public IActionResult AntDuzenle(Antrenor antrenor)
        {
            if (ModelState.IsValid)
            {
                _context.Antrenor.Update(antrenor);
                _context.SaveChanges();
                return RedirectToAction("AntList");
            }
            return View(antrenor);
        }
        //-----Listeleme İşlemi-----
        public IActionResult AntList()
        {
            var antrenorler = _context.Antrenor.ToList();
            return View(antrenorler);
        }

        //-----Delete İşlemi-----
        public IActionResult AntSil(int id)
        {
            if (id <= 0)
                return NotFound();

            var antrenor = _context.Antrenor.FirstOrDefault(a => a.ID == id);

            if (antrenor == null)
                return NotFound();

            return View(antrenor);
        }
        [HttpPost]
        public IActionResult AntSilOnay(int id)
        {
            var antrenor = _context.Antrenor.FirstOrDefault(a => a.ID == id);

            if (antrenor == null)
                return NotFound();

            _context.Antrenor.Remove(antrenor);
            _context.SaveChanges();

            return RedirectToAction("AntList");

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
