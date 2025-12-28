using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using webProject.Data;
using webProject.Models;

namespace webProject.Controllers
{
    [Authorize]
    [Authorize(Roles = "Admin")]
    public class AntHizmetController : Controller
    {
        private readonly FitnessDbContext _context;

        public AntHizmetController(FitnessDbContext context)
        {
            _context = context;
        }
        //-----Create İşlemi-----
        public IActionResult AntHizOlustur()
        {
            ViewData["Antrenorler"] = new SelectList(_context.Antrenor, "ID", "Ad");
            ViewData["Hizmetler"] = new SelectList(_context.Hizmet, "ID", "Ad");
            return View();
        }

        [HttpPost]
        public IActionResult AntHizOlustur(int antrenorId, int hizmetId)
        {
            // Aynı ilişki var mı kontrolü
            bool varMi = _context.AntHizmet.Any(x =>
                x.AntrenorID == antrenorId &&
                x.HizmetID == hizmetId);

            if (varMi)
            {
                ModelState.AddModelError("", "Bu antrenör zaten bu hizmeti veriyor.");
            }

            if (ModelState.IsValid)
            {
                var antHizmet = new AntHizmet
                {
                    AntrenorID = antrenorId,
                    HizmetID = hizmetId
                };

                _context.AntHizmet.Add(antHizmet);
                _context.SaveChanges();

                return RedirectToAction("AntHizList");
            }

            ViewData["Antrenorler"] = new SelectList(_context.Antrenor, "ID", "Ad");
            ViewData["Hizmetler"] = new SelectList(_context.Hizmet, "ID", "Ad");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AntHizSil(int id)
        {
            var antHizmet = _context.AntHizmet.FirstOrDefault(x => x.ID == id);
            if (antHizmet == null)
                return NotFound();

            _context.AntHizmet.Remove(antHizmet);
            _context.SaveChanges();

            return RedirectToAction("Index", "Antrenor");
        }
        public IActionResult AntHizList()
        {
            var liste = _context.AntHizmet
                .Include(x => x.Antrenor)
                .Include(x => x.Hizmet)
                .ToList();

            return View(liste);
        }
        public IActionResult Index()
        {
            var liste = _context.AntHizmet
                .Include(x => x.Antrenor)
                .Include(x => x.Hizmet)
                .ToList();

            return View(liste);
        }

    }
}
