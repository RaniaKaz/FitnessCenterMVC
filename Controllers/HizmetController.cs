using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webProject.Data;
using webProject.Models;

namespace webProject.Controllers
{
    [Authorize]
    public class HizmetController : Controller
    {
        private readonly FitnessDbContext _context;
        public HizmetController(FitnessDbContext context)
        {
            _context = context;
        }

        //-----Create İşlemi-----
        [Authorize(Roles = "Admin")]
        public IActionResult HizOlustur()
        {

            return View();
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult HizOlustur(Hizmet hizmet)
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
        [AllowAnonymous]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult HizList()
        {
            var hizmetler = _context.Hizmet.ToList();
            return View(hizmetler);
        }

        //-----Delete İşlemi-----
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult HizSilOnay(int id)
        {
            var hizmet = _context.Hizmet.FirstOrDefault(h => h.ID == id);

            if (hizmet == null)
                return NotFound();

            _context.Hizmet.Remove(hizmet);
            _context.SaveChanges();

            return RedirectToAction("HizList");

        }
        
        [AllowAnonymous]
        public IActionResult Index()
        {
            var hizmetler = _context.Hizmet.ToList();
            return View(hizmetler);
        }
    }
}
