using Lesson_56_HT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Lesson_56_HT.Repositories;

namespace Lesson_56_HT.Controllers
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
            CityRepository cityRepository = new();
            return View(cityRepository.CityList);
        }

        public IActionResult Visa()
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
