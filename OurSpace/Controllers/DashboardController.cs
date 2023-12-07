﻿using Microsoft.AspNetCore.Mvc;
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

        var bookings = _dbData.bookings.ToList();
        var accepted = _dbData.accepted.ToList();

        var viewModel = new TwoModelViewModel
        {
            Bookings = bookings,
            Accepted = accepted
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
        if (!ModelState.IsValid)
            return View();

        _dbData.bookings.Add(newBookings);
        _dbData.SaveChanges();
        return View("Index", _dbData.bookings);
    }

    //[HttpGet]
    //public IActionResult AddHomeroomBookings()
    //{
    //    return View();
    //}

    //[HttpPost]
    //public IActionResult AddHomeroomBookings(Bookings newBookings)
    //{
    //    if (!ModelState.IsValid)
    //        return View();

    //    _dbData.bookings.Add(newBookings);
    //    _dbData.SaveChanges();
    //    return View("Index", _dbData.bookings);
    //}

    //[HttpGet]
    //public IActionResult UpdateUser(int id)
    //{
    //    Bookings? bookings = _dbData.bookings.FirstOrDefault(st => st.BId == id);

    //    if (bookings != null)//was an instructor found?
    //        return View(bookings);

    //    return NotFound();
    //}

    //[HttpPost]
    //public IActionResult UpdateUser(Bookings bookingsChanges)
    //{
    //    Bookings? bookings = _dbData.bookings.FirstOrDefault(st => st.BId == bookingsChanges.BId);

    //    if (bookings != null)
    //    {
    //        bookings.BName = bookingsChanges.BName;
    //        bookings.BEmail = bookingsChanges.BEmail;
    //        bookings.BCNum = bookingsChanges.BCNum;
    //        bookings.BDate = bookingsChanges.BDate;
    //        bookings.BTime = bookingsChanges.BTime;
    //        bookings.BMessage = bookingsChanges.BMessage;
    //        _dbData.SaveChanges();
    //    }

    //    return RedirectToAction("Index");
    //}

    [HttpGet]
    public IActionResult creativesCancel(int id)
    {

        Bookings? bookings = _dbData.bookings.FirstOrDefault(st => st.BId == id);
        if (bookings != null)
        {
            return View(bookings);
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult creativesCancel(Bookings newBookings)
    {
        Bookings? bookings = _dbData.bookings.FirstOrDefault(st => st.BId == newBookings.BId);

        if (bookings != null)
            _dbData.bookings.Remove(bookings);
        return View("/Index", _dbData.bookings);
    }
}
