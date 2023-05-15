using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  private MyContext _context;
  public HomeController(ILogger<HomeController> logger, MyContext context)
  {
    _logger = logger;
    _context = context;
  }

  [SessionCheck]
  [HttpGet("dashboard")]
  public IActionResult Dashboard()
  {
    ViewBag.AllWeddings = _context.Weddings.Include(r => r.PeopleGoing).ThenInclude(u => u.User).ToList();
    return View();
  }

  [SessionCheck]
  [HttpGet("weddings/new")]
  public IActionResult WeddingForm()
  {
    return View();
  }

  [HttpPost("weddings/create")]
  public IActionResult CreateWedding(Wedding newWedding)
  {
    if (ModelState.IsValid)
    {
      _context.Add(newWedding);
      _context.SaveChanges();
      return RedirectToAction("ShowWedding", new { wedId = newWedding.WeddingId });
    }
    else
    {
      return View("WeddingForm");
    }
  }

  [SessionCheck]
  [HttpGet("weddings/{wedId}")]
  public IActionResult ShowWedding(int wedId)
  {
    Wedding? OneWedding = _context.Weddings.Include(r => r.PeopleGoing.OrderBy(u => u.User.FirstName)).ThenInclude(u => u.User).FirstOrDefault(wed => wed.WeddingId == wedId);
    return View(OneWedding);
  }

  [HttpPost("weddings/{wedId}/going")]
  public IActionResult RSVPToggle(int wedId)
  {
    RSVP? existingRSVP = _context.RSVPs.FirstOrDefault(r => r.WeddingId == wedId && r.UserId == (int)HttpContext.Session.GetInt32("UserId"));

    if (existingRSVP == null)
    {
      RSVP newRSVP = new RSVP()
      {
        WeddingId = wedId,
        UserId = (int)HttpContext.Session.GetInt32("UserId")
      };

      _context.Add(newRSVP);
    }
    else
    {
      _context.RSVPs.Remove(existingRSVP);
    }
    _context.SaveChanges();
    return RedirectToAction("Dashboard");
  }

  [HttpPost("weddings/{wedId}/destroy")]
  public IActionResult DestroyWedding(int wedId)
  {
    Wedding? weddingToDelete = _context.Weddings.SingleOrDefault(wed => wed.WeddingId == wedId);
    _context.Weddings.Remove(weddingToDelete);
    _context.SaveChanges();
    return RedirectToAction("Dashboard");
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}