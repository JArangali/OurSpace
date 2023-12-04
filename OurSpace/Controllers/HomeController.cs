using Microsoft.AspNetCore.Mvc;
using OurSpace.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using OurSpace.Data;
using OurSpace.Database;

namespace OurSpace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbData;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbData)
        {
            _logger = logger;
            _dbData = dbData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Hubs()
        {
            return View();
        }
        public IActionResult login()
        {
            return View("Accounts");
        }

        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}