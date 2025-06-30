using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      var hour = DateTime.Now.Hour;
      var minute = DateTime.Now.Minute;
      var second = DateTime.Now.Second;
      ViewBag.Hour = hour;
      ViewBag.Minute = minute;
      ViewBag.Second = second;
      return View();
    }

    [HttpGet]
    public IActionResult RsvpForm()
    {
      return View();
    }

    [HttpPost]
    public IActionResult RsvpForm(GuestResponse guestResponse)
    {
      if (ModelState.IsValid)
      {
        return View("Thanks", guestResponse);
      }
      else
      {
        return View();
      }
    }


    public IActionResult Privacy()
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
