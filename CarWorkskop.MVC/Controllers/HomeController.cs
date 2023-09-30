using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarWorkskop.MVC.Models;

namespace CarWorkskop.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult NoAccess()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        var aboutModel = new List<About>()
        {
            new About()
            {
                Title = "Nowy tytuł",
                Description = "Nowy opis",
                Tags = new List<string> {"tag1", "tag2"}
            },
            new About()
            {
                Title = "Nowy tytuł2",
                Description = "Nowy opis2",
                Tags = new List<string> {"tag3", "tag4"}

            },
        };
        return View(aboutModel);
    }

    public IActionResult Contact()
    {
        var contactModel = new Contact()
        {
            Phone = 1234456,
            Email = "myEmail@wp.pl"
        };
        return View(contactModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
