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

        public IActionResult Index(int? Category, string? SearchString, string? Brand)
        {
            List<SelectListItem> CategoriesSelectList = new() {
            new SelectListItem { Text = "Choose", Value = "", Disabled = true, Selected = true }
                };
            CategoriesSelectList.AddRange( new SelectList(CategoryRepository.GetCategories(), "ID", "Name").ToList());


            ViewBag.CategoriesSelect = CategoriesSelectList;
            ViewBag.BrandsList = new List<string>() { "Apple", "Sony", "Samsung" };

            List<Product> ProductList = ProductRepository.GetProducts();

            if (Category is not null && Category != 0) {
                ProductList = ProductRepository.GetProductByCategory(Category);
            }

            if (SearchString is not null)
            {
                ProductList = ProductRepository.GetProductsByName(SearchString);
            }

            if(Brand is not null)
            {
                ProductList = ProductRepository.GetProductsByName(Brand);
            }

            return View(ProductList);
        }

        


        public IActionResult Details(int id)
        {
            ProductRepository.BuyProductByID(id);
            return View(ProductRepository.GetProductByID(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
