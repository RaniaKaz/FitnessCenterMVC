using Microsoft.AspNetCore.Mvc;

namespace webProject.Controllers
{
    public class HizmetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
