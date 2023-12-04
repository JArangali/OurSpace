using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OurSpace.Controllers
{
    public class About : Controller
    {
        public class AboutController : Controller
        {
            public IActionResult Index() 
            { 
            return View();
            }
        }  
    }
}
