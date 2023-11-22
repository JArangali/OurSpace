using Microsoft.AspNetCore.Mvc;

namespace OurSpace.Controllers
{
    public class About : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
