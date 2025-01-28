using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Diagnostics;
using Udemy.DAL;
using Udemy.DAL.Interfaces;
using Udemy.Entity;
using Udemy.Models;
using Udemy.ViewModels;

namespace Udemy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
		
		private ICourseRepository _courseRepository;
        private ICategoryRepository _categoryRepository;



        public HomeController(IConfiguration configuration)
		{
			_configuration = configuration;

			_courseRepository = new CourseRepository(new AppDbContext(_configuration));
			_categoryRepository = new CategoryRepository(new AppDbContext(_configuration));
		}

		public IActionResult Index()
        {
            ViewBag.Courses = _courseRepository.GetCoursesWithCategories();
			ViewBag.Categories = _categoryRepository.GetCategories();
			return View();
        }


		public IActionResult CourseDetail(int id)
		{
			ViewBag.Categories = _categoryRepository.GetCategories();

			return View(_courseRepository.GetCourseById(id));
		}


		public IActionResult FilteredCourses(int id)
		{

			ViewBag.FilteredCourses = _courseRepository.GetCoursesByCategory(id);
            ViewBag.Categories = _categoryRepository.GetCategories();

            return View();
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login(string email,string password)
		{
            AppDbContext appDbContext = new AppDbContext(_configuration);
            var admins = appDbContext.Admins.ToList();
			foreach(var admin in admins)
			{
                if (admin.Email == email && admin.Password == password)
				{
					return RedirectToAction("Dashboard");
				}

            }

            return View();
		}

		public IActionResult Dashboard()
		{

			return View();
		}
		[HttpGet]
		public IActionResult AddCourse()
        {
            ViewBag.Categories = _categoryRepository.GetCategories();
            return View();
        }
		[HttpPost]
		public IActionResult AddCourse(string name ,string description,int categoryId)
		{
			_courseRepository.AddCourse(
				new Course() 
				{ Name = name, Description = description, CategoryId = categoryId }
			);

            return RedirectToAction("Index");
        }

		[HttpGet]
		public IActionResult DeleteCourse(int? id)
		{
            ViewBag.Courses = _courseRepository.GetCoursesWithCategories();
            ViewBag.Categories = _categoryRepository.GetCategories();

            return View();
		}
		public IActionResult RemoveCourse(int Id)
		{
			_courseRepository.DeleteCourse(
				_courseRepository.GetCourseById(Id));
			return RedirectToAction("DeleteCourse");
		}





	}
}
