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

        var user = _dbData.AspNetUsers.FirstOrDefault(F => F.UserName == User.Identity.Name);
        var bookings = _dbData.bookings.Where(B => B.BStatus == "Pending" && B.BHub == user.AdminCode).ToList();
        var accepted = _dbData.bookings.Where(B => B.BStatus == "Accepted" && B.BHub == user.AdminCode).ToList();
        var completed = _dbData.bookings.Where(B => B.BStatus == "Completed" && B.BHub == user.AdminCode).ToList();
        var archive = _dbData.bookings.Where(B => (B.BStatus == "Cancelled" || B.BStatus == "Declined") && B.BHub == user.AdminCode).ToList();

        var viewModel = new TwoModelViewModel
        {
            Bookings = bookings,
            Accepted = accepted,
            Completed = completed,
            Archive = archive
        };

        return View(viewModel);
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
            return RedirectToAction("Index", "Home");
        }
        var toAdd = newBookings;
        toAdd.BStatus = "Pending";

        _dbData.bookings.Add(toAdd);
        _dbData.SaveChanges();
        return RedirectToAction("Index", "Dashboard");
    }
    [HttpGet]
    public IActionResult DashboardAccept(int id)
    {
        Bookings? newAccepted = _dbData.bookings.FirstOrDefault(st => st.BId == id);

        var toUpdate = newAccepted;
        toUpdate.BStatus = "Accepted";

        _dbData.bookings.Update(toUpdate);
        _dbData.SaveChanges();
        return RedirectToAction("Index", "Dashboard");
    }

    [HttpGet]
    public IActionResult DashboardComplete(int id)
    {
        Bookings? newComplete = _dbData.bookings.FirstOrDefault(st => st.BId == id);

        var toComplete = newComplete;
        toComplete.BStatus = "Completed";

        _dbData.bookings.Update(toComplete);
        _dbData.SaveChanges();
        return RedirectToAction("Index", "Dashboard");
    }

    [HttpGet]
    public IActionResult DashboardCancelled(int id)
    {
        Bookings? newArchive = _dbData.bookings.FirstOrDefault(st => st.BId == id);

        var toArchive = newArchive;
        toArchive.BStatus = "Cancelled";

        _dbData.bookings.Update(toArchive);
        _dbData.SaveChanges();
        return RedirectToAction("Index", "Dashboard");
    }

    [HttpGet]
    public IActionResult DashboardDeclined(int id)
    {
        Bookings? newArchive = _dbData.bookings.FirstOrDefault(st => st.BId == id);

        var toArchive = newArchive;
        toArchive.BStatus = "Declined";

        _dbData.bookings.Update(toArchive);
        _dbData.SaveChanges();
        return RedirectToAction("Index", "Dashboard");
    }
}