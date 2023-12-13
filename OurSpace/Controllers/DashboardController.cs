using Microsoft.AspNetCore.Mvc;
using OurSpace.Models;
using OurSpace.Data;

public class DashboardController : Controller
{
    private readonly AddDbContext _dbData;

    public DashboardController(AddDbContext dbData)
    {
        _dbData = dbData;
    }

    public IActionResult Index()
    {

        var bookings = _dbData.bookings.Where(B=>B.BStatus == "Pending").ToList();
        var accepted = _dbData.bookings.Where(B => B.BStatus == "Accepted").ToList();
        var completed = _dbData.bookings.Where(B => B.BStatus == "Completed").ToList();
        var archive = _dbData.bookings.Where(B => B.BStatus == "Cancelled" || B.BStatus == "Declined").ToList();

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
        Bookings? bookings = _dbData.bookings.FirstOrDefault(st => st.BId == id);

        if (bookings != null)
            return View(bookings);

        return NotFound();
    }


    [HttpGet]
    public IActionResult AddBookings()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddBookings(Bookings newBookings)
    {
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
    public IActionResult DashboardCanceled(int id)
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