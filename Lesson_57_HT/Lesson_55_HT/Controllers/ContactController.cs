using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lesson_55_HT.Models;
using Lesson_55_HT.Repository;


namespace Lesson_55_HT.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ContactRepository contactRepository = new();
            return View(contactRepository.ContactsList);
        }

        public IActionResult Details(int id)
        {
            ContactRepository contactRepository = new();

            Contact? currentContact = contactRepository.GetByID(id);

            if (currentContact is null)
            {
                return RedirectToAction("Index", "Contact");
            }

            return View(currentContact);
        }


    }
}

