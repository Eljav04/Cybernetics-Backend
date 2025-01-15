using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lesson_60_HT.Scaf_Models;
using Lesson_60_HT.Repos;

namespace Lesson_60_HT.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ProductRepo productRepo = new();
        return View(productRepo.ProductsList);
    }

    public IActionResult Privacy()
    {
        return View();
    }

}

