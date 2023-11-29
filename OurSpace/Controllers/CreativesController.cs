using Microsoft.AspNetCore.Mvc;

namespace OurSpace.Controllers
{
    public class Creatives : Controller
    {
        public IActionResult creatives()
        {
            return View();
        }
    }
}
