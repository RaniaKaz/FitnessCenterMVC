using Microsoft.AspNetCore.Mvc;
using webProject.Data;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webProject.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UyeApiController : ControllerBase
    {
        private readonly FitnessDbContext _context;
        public UyeApiController(FitnessDbContext context)
        {
            _context = context;
        }
        // GET: api/<UyeApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UyeApi/1/randevular
        [HttpGet("{uyeId}/randevular")]
        public ActionResult GetUyeRandevular(int uyeId)
        {
            var randevular = _context.Randevu
                .Where(r => r.UyeID == uyeId)
                .Select(r => new {
                    r.ID,
                    r.RandevuTarihi,
                    Hizmet = r.Hizmet.Ad,
                    Antrenor = r.Antrenor.Ad + " " + r.Antrenor.Soyad
                })
                .ToList();

            return Ok(randevular);
        }

        // POST api/<UyeApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UyeApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UyeApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
