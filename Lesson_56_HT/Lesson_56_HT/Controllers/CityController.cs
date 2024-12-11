using Lesson_56_HT.Repositories;
using Microsoft.AspNetCore.Mvc;
using Lesson_56_HT.Models;

namespace Lesson_56_HT.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Details(int id)
        {
            CityRepository cityRepository = new();
            City? result = cityRepository.GetCityById(id);

            if (result is null) 
            { 
                return NotFound();
            }


            return View(result);
        }

        [HttpPost]
        public IActionResult GetUserData(User user)
        {
            Console.WriteLine(user.FullName);
            return RedirectToAction("Index", "Home");
        }
    }
}
