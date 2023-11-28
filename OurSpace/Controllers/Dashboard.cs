using Microsoft.AspNetCore.Mvc;

namespace OurSpace.Controllers
{
    public class Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
