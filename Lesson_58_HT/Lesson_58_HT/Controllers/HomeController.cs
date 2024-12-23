using Lesson_58_HT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Lesson_58_HT.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Lesson_58_HT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? Category)
        {
            SelectList CategoriesSelectList = new SelectList(CategoryRepository.GetCategories(), "ID", "Name");
            ViewBag.CategoriesSelect = CategoriesSelectList;

            List<Product> ProductList = ProductRepository.GetProducts();

            if (Category is not null) {
                ProductList = ProductRepository.GetProductByCategory(Category);
            }

            return View(ProductList);
        }

        public IActionResult Details(int id)
        {
            return View(ProductRepository.GetProductByID(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
