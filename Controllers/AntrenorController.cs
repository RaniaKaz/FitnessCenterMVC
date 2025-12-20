using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webProject.Data;
using webProject.Models;

namespace webProject.Controllers
{
    public class AntrenorController : Controller
    {
        int sayi = 0;
        private readonly FitnessDbContext _context;
        public AntrenorController(FitnessDbContext context)
        {
            _context = context;
        }
        public IActionResult HizmetSec(int id)
        {
            var antrenor = _context.Antrenor.Include(a => a.AntHizmetler)
                .FirstOrDefault(a => a.ID == id);
            if (antrenor == null)
                return NotFound();

            var hizmetler = _context.Hizmet.ToList();

            var model = new AntrenorHizmetSecViewModel
            {
                AntID = id,
                AntAdSoyad = antrenor.Ad + " " + antrenor.Soyad,
                Hizmetler = hizmetler.Select(h => new HizmetSecItem
                {
                    ID = h.ID,
                    Ad = h.Ad,
                    SeciliMi = antrenor.AntHizmetler.Any(ah => ah.HizID == h.ID)
                }).ToList()

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult HizmetSec(AntrenorHizmetSecViewModel model)
        {
            var antrenor = _context.Antrenor.Include(a=> a.AntHizmetler)
                .FirstOrDefault(a=> a.ID == model.AntID);

            if (antrenor == null)
                return NotFound();
            //tek tek sorgulamak yerine hepsini sil
            _context.AntHizmet.RemoveRange(antrenor.AntHizmetler);

            foreach(var item in model.Hizmetler.Where(x => x.SeciliMi))
            {
                _context.AntHizmet.Add(new AntHizmet
                {
                    AntID = antrenor.ID,
                    HizID = item.ID
                });
            }
            _context.SaveChanges();
            return RedirectToAction("AntDetay", new {id = model.AntID}); 
        }
        //-----Create İşlemi-----
        public IActionResult AntOlustur()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AntOlustur(Antrenor antrenor)
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
