using Microsoft.AspNetCore.Mvc;

namespace webProject.Controllers
{
    public class HesapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
