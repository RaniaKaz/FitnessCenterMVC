using Microsoft.AspNetCore.Mvc;
using webProject.Data;
using webProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webProject.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AntrenorApiController : ControllerBase
    {
        private readonly FitnessDbContext _context;

        public AntrenorApiController(FitnessDbContext context)
        {
            _context = context;
        }

        // GET: api/<AntrenorApiController>
        [HttpGet]
        public List<Antrenor> Get()
        {
            var antrenorler = _context.Antrenor.ToList();
            return antrenorler;
        }

        // GET api/<AntrenorApiController>/5
        [HttpGet("{id}")]
        public ActionResult<Antrenor> Get(int id)
        {
            var antrenor = _context.Antrenor.FirstOrDefault(r => r.ID == id);

            if(antrenor == null )
            {
                return NotFound();
            }
            return antrenor;
        }
        // GET: api/AntrenorApi/uygun?gun=Monday&saat=10:00
        [HttpGet("uygun")]
        public ActionResult UygunAntrenoler(DayOfWeek gun, TimeSpan saat)
        {
            var uygunlar = _context.Antrenor
                .Where(a => a.Musaitlik.Any(m =>
                    m.Gun == gun &&
                    m.Baslangic <= saat &&
                    m.Bitis >= saat))
                .Select(a => new {
                    a.ID,
                    a.Ad,
                    a.Soyad
                })
                .ToList();

            return Ok(uygunlar);
        }
        // POST api/<AntrenorApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AntrenorApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AntrenorApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
