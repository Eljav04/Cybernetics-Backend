using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Lesson_58_HT.Models;
using Lesson_58_HT.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.AspNetCore.Authorization;

namespace Lesson_58_HT.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHostingEnvironment env;

        public AdminController(IHostingEnvironment env)
        {
            this.env = env;
        }

        public IActionResult Login(Admin admin)
        {
            if (AdminRepository.CheckExistence(admin))
            {
                TempData["isLogged"] = true;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["isLogged"] = false;
            }
            return View();
        }

        public bool CheckAdminSession()
        {
            if (TempData["isLogged"] is null)
            {
                return false;
            }
            else
            {
                bool isLogged = Convert.ToBoolean(TempData["isLogged"]);
                if (!isLogged)
                {
                    return false;
                }
            }

            return true;
        }

        public IActionResult Index()
        {
            if (!CheckAdminSession())
            {
                return RedirectToAction("Login", "Admin");
            }
            TempData["isLogged"] = true;
            return View();
        }

        public IActionResult Add()
        {
            if (!CheckAdminSession())
            {
                return RedirectToAction("Login", "Admin");
            }

            SelectList CategoriesSelectList = new SelectList(CategoryRepository.GetCategories(), "ID", "Name");
            ViewBag.CategoriesSelect = CategoriesSelectList;
            ViewBag.IsUploadImg = true;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product, IFormFile productImg)
        {
            SelectList CategoriesSelectList = new SelectList(CategoryRepository.GetCategories(), "ID", "Name");
            ViewBag.CategoriesSelect = CategoriesSelectList;

            if (productImg != null)
            {
                var fileName = Path.Combine(
                    env.WebRootPath + "/uploaded", 
                    Path.GetFileName(productImg.FileName));

                productImg.CopyTo(new FileStream(fileName, FileMode.Create));

                product.Image =  "~/uploaded/" + 
                    Path.GetFileName(productImg.FileName);
            }
            else
            {
                ViewBag.IsUploadImg = false;
                return View(product);
            }

            if (!ModelState.IsValid)
            {
                ViewBag.IsUploadImg = true;
                return View(product);
            }

            ProductRepository.AddProduct(product);
            return RedirectToAction("Index", "Admin");

        }

        public IActionResult Update(int? productId)
        {

            if (!CheckAdminSession())
            {
                return RedirectToAction("Login", "Admin");
            }
            TempData["isLogged"] = true;

            ViewBag.CategoriesSelect = new SelectList(CategoryRepository.GetCategories(), "ID", "Name");
            ViewBag.ProductsSelect = new SelectList(ProductRepository.GetProducts(), "ID", "Name");

            if (productId != null)
            {
                return View(ProductRepository.GetProductByID(productId));
            }
            return View();
        }

        [HttpPost]
        public IActionResult Update(Product product, int CategoryID)
        {
            ViewBag.CategoriesSelect = new SelectList(CategoryRepository.GetCategories(), "ID", "Name");
            ViewBag.ProductsSelect = new SelectList(ProductRepository.GetProducts(), "ID", "Name");

            if (ModelState.IsValid)
            {
                product.CategoryID = CategoryID;
                ProductRepository.Update(product);

                TempData["isLogged"] = false;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete()
        {
            if (!CheckAdminSession())
            {
                return RedirectToAction("Login", "Admin");
            }
            return View(ProductRepository.GetProducts());
        }

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            ProductRepository.DeleteByID(productId);
            return RedirectToAction("Index", "Admin");
        }
    }
}
