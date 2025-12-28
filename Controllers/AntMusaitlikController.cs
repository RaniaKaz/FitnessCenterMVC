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
    public class AntMusaitlikController : Controller
    {
        private readonly FitnessDbContext _context;

        public AntMusaitlikController(FitnessDbContext context)
        {
            _context = context;
        }

        // ===================== LIST =====================
        public IActionResult AntMusaitlikList()
        {
            var musaitlikler = _context.AntMusaitlik
                .Include(m => m.Antrenor)
                .ToList();

            return View(musaitlikler);
        }

        // ===================== CREATE (GET) =====================
        public IActionResult AntMusaitlikOlustur()
        {
            ViewData["AntrenorID"] = new SelectList(_context.Antrenor, "ID", "Ad");
            return View();
        }

        // ===================== CREATE (POST) =====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AntMusaitlikOlustur(AntMusaitlik musaitlik)
        {
            if (ModelState.IsValid)
            {
                _context.AntMusaitlik.Add(musaitlik);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AntrenorID"] = new SelectList(_context.Antrenor, "ID", "Ad", musaitlik.AntrenorID);
            return View(musaitlik);
        }

        // ===================== DELETE (GET) =====================
        public IActionResult AntMusaitlikSil(int id)
        {
            var musaitlik = _context.AntMusaitlik
                .Include(m => m.Antrenor)
                .FirstOrDefault(m => m.ID == id);

            if (musaitlik == null)
                return NotFound();

            return View(musaitlik);
        }

        // ===================== DELETE (POST) =====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AntMusaitlikSilOnay(int id)
        {
            var musaitlik = _context.AntMusaitlik.Find(id);

            if (musaitlik == null)
                return NotFound();

            _context.AntMusaitlik.Remove(musaitlik);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var musaitlikler = _context.AntMusaitlik
                .Include(m => m.Antrenor)
                .OrderBy(m => m.Antrenor.Ad)
                .ThenBy(m => m.Gun)
                .ThenBy(m => m.Baslangic)
                .ToList();

            return View(musaitlikler);
        }

    }
}
