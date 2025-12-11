using Microsoft.AspNetCore.Mvc;
using webProject.Data;
using webProject.Models;
namespace webProject.Controllers
{
    public class UyeController : Controller
    {
        private readonly FitnessDbContext _context;

        // 🔹 DbContext burada otomatik geliyor (DI)
        public UyeController(FitnessDbContext context)
        {
            _context = context;
        }
        //-----Create İşlemi-----
        public IActionResult UyeOlustur()
        {

            return View();
        }

        public IActionResult UyeEkle(Uye uye)
        {
            if (ModelState.IsValid)
            {
                _context.Uye.Add(uye);
                _context.SaveChanges();
                return RedirectToAction("UyeList");
            }
            return View("UyeOlustur");
        }
        //-----Detay İşlemi-----
        public IActionResult UyeDetay(int id)
        {
            if(id <= 0)
                return NotFound();

            var uye = _context.Uye.FirstOrDefault(u => u.ID == id);  
            
            if(uye == null)
                return NotFound();

            return View(uye);
        }
        //-----Düzenleme İşlemi-----
        public IActionResult UyeDuzenle(int id)
        {
            if (id <= 0)
                return NotFound();

            var uye = _context.Uye.FirstOrDefault(u => u.ID == id);
            return View(uye);
        }
        [HttpPost]
        public IActionResult UyeDuzenle(Uye uye)
        {
            if (ModelState.IsValid)
            {
                _context.Uye.Update(uye);
                _context.SaveChanges();
                return RedirectToAction("UyeList");
            }
            return View(uye);
        }
        //-----Listeleme İşlemi-----
        public IActionResult UyeList()
        {
            var uyeler = _context.Uye.ToList();
            return View(uyeler);
        }

        //-----Delete İşlemi-----
        public IActionResult UyeSil(int id)
        {
            if(id <= 0)
                return NotFound();

            var uye = _context.Uye.FirstOrDefault(u => u.ID == id);

            if(uye == null)
                return NotFound();

            return View(uye);
        }
        [HttpPost]
        public IActionResult UyeSilOnay(int id)
        {
            var uye = _context.Uye.FirstOrDefault(u => u.ID == id);

            if (uye == null)
                return NotFound();

             _context.Uye.Remove(uye);
             _context.SaveChanges();

            return RedirectToAction("UyeList");
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
