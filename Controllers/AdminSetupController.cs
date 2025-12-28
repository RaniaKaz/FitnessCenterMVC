using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using webProject.Models;

namespace webProject.Controllers
{
    [Authorize]
    public class AdminSetupController : Controller
    {
  
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUsers> _userManager;

        public AdminSetupController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUsers> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> CreateAdmin()
        {
            // 1️⃣ Roller
            if(!await _roleManager.RoleExistsAsync("Admin"))
            await _roleManager.CreateAsync(new IdentityRole("Admin"));

            if(!await _roleManager.RoleExistsAsync("Uye"))
                await _roleManager.CreateAsync(new IdentityRole("Uye"));

            // 2️⃣ Admin Kullanıcı
            var adminEmail = "G231210557@sakarya.edu.tr";
            var adminUser = await _userManager.FindByEmailAsync(adminEmail);

            if(adminUser == null)
                return Content("Admin user bulunamadı! Önce register yap");

            // 3️⃣ Admin Kullanıcıya Admin Rolünü Ata
            if(!await _userManager.IsInRoleAsync(adminUser, "Admin"))
                await _userManager.AddToRoleAsync(adminUser, "Admin");

            return Content("Admin rolü ve kullanıcı ataması yapıldı. Artık bu controller silinebilir.");

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
