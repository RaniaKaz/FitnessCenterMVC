using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webProject.Data;
using webProject.Models;
namespace webProject.Controllers
{
    [Authorize]
    public class UyeController : Controller
    {
        private readonly FitnessDbContext _context;
        private readonly UserManager<ApplicationUsers> _userManager;

        // 🔹 DbContext burada otomatik geliyor (DI)
        public UyeController(FitnessDbContext context, UserManager<ApplicationUsers> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        //-----Create İşlemi-----
        [Authorize(Roles = "Admin")]
        public IActionResult UyeOlustur()
        {

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult UyeOlustur(Uye uye)
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult UyeDuzenle(int id)
        {
            if (id <= 0)
                return NotFound();

            var uye = _context.Uye.FirstOrDefault(u => u.ID == id);
            return View(uye);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult UyeList()
        {
            var uyeler = _context.Uye.ToList();
            return View(uyeler);
        }

        //-----Delete İşlemi-----
        [Authorize(Roles = "Admin")]
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
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult UyeSilOnay(int id)
        {
            var uye = _context.Uye.FirstOrDefault(u => u.ID == id);

            if (uye == null)
                return NotFound();

            var user = _context.Users.FirstOrDefault(u => u.UyeID == uye.ID);
            if (user != null)
            {
                _userManager.DeleteAsync(user);
            }
            _context.Uye.Remove(uye);
             _context.SaveChanges();

            return RedirectToAction("UyeList");
            
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var uyeler = _context.Uye.ToList();
            return View(uyeler);
        }
        [Authorize(Roles = "Uye")]
        public async Task<IActionResult> UserPaneli()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }

    }
}
