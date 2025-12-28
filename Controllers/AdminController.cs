using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webProject.Data;

namespace webProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly FitnessDbContext _context;

        public AdminController(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.UyeSayisi = _context.Uye.Count();
            ViewBag.AntrenorSayisi = _context.Antrenor.Count();
            ViewBag.HizmetSayisi = _context.Hizmet.Count();
            ViewBag.BekleyenRandevu = _context.Randevu.CountAsync(r => !r.OnayDurumu);
            return View();
        }
    }
}
