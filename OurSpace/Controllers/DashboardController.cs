using Microsoft.AspNetCore.Mvc;
using OurSpace.Models;
using OurSpace.Data;

public class DashboardController : Controller
{
    private readonly AppDbContext _dbData;

    public DashboardController(AppDbContext dbData)
    {
        _dbData = dbData;
    }

    public IActionResult Index()
    {
        if(!User.Identity.IsAuthenticated) 
        {
            return RedirectToAction("Login", "Account");
        }
        return View(_dbData.bookings);
    }

    public IActionResult ShowDetail(int id)
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }

        Bookings? bookings = _dbData.bookings.FirstOrDefault(st => st.BId == id);

        if (bookings != null)
            return View(bookings);

        return NotFound();
    }

    [HttpGet]
    public IActionResult AddBookings()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }
        return View();
    }

    [HttpPost]
    public IActionResult AddBookings(Bookings newBookings)
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }
        if (!ModelState.IsValid)
            return View();

        _dbData.bookings.Add(newBookings);
        _dbData.SaveChanges();
        return View("Index", _dbData.bookings);
    }

    [HttpGet]
    public IActionResult AddHomeroomBookings()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }
        return View();
    }

    [HttpPost]
    public IActionResult AddHomeroomBookings(Bookings newBookings)
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }
        if (!ModelState.IsValid)
            return View();

        _dbData.bookings.Add(newBookings);
        _dbData.SaveChanges();
        return View("Index", _dbData.bookings);
    }

    [HttpGet]
    public IActionResult UpdateInstructor(int id)
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }
        Bookings? bookings = _dbData.bookings.FirstOrDefault(st => st.BId == id);

        if (bookings != null)//was an instructor found?
            return View(bookings);

        return NotFound();
    }

    [HttpPost]
    public IActionResult UpdateBookings(Bookings bookingsChanges)
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }
        Bookings? bookings = _dbData.bookings.FirstOrDefault(st => st.BId == bookingsChanges.BId);

        if (bookings != null)
        {
            bookings.BName = bookingsChanges.BName;
            bookings.BEmail = bookingsChanges.BEmail;
            bookings.BCNum = bookingsChanges.BCNum;
            bookings.BDate = bookingsChanges.BDate;
            bookings.BTime = bookingsChanges.BTime;
            bookings.BMessage = bookingsChanges.BMessage;
            _dbData.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Done(int id)
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }
        Bookings? bookings = _dbData.bookings.FirstOrDefault(st => st.BId == id);

        if (bookings != null)//was an instructor found?
            return View(bookings);

        return NotFound();
    }

    [HttpPost]
    public IActionResult Done(Bookings newBookings)
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }
        Bookings? bookings = _dbData.bookings.FirstOrDefault(st => st.BId == newBookings.BId);

        if (bookings != null)
            _dbData.bookings.Remove(bookings);
        return RedirectToAction("Index");
    }
}
