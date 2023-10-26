using Microsoft.AspNetCore.Mvc;

namespace OurSpace.Controllers
{
    public class HubsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
