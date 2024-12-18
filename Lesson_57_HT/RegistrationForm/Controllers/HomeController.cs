using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegistrationForm.Models;
using RegistrationForm.Repository;

namespace RegistrationForm.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                UserRepository.AddUser(user);
                return View("Reply", user);
            }

            return View(user);

        }

        public IActionResult Reply()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(UserRepository.GetUsers());
        }
    }
}

