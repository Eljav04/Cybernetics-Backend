using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson_56_HT.Repositories;
using Microsoft.AspNetCore.Mvc;
using Lesson_56_HT.Models;


namespace Lesson_56_HT.Controllers
{
    public class AdminController : Controller
    {
        //public UserRequestRepository UsersRequests = new();

        public IActionResult AddUserRequest(User user)
        {
            UserRequestRepository.AddUser(user);

            return RedirectToAction("Index", "Home");

        }

        public IActionResult UserRequest()
        {
            return View(UserRequestRepository.UserRequestList);
        }
    }
}

