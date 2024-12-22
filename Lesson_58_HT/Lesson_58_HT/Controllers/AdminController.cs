using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Lesson_58_HT.Models;
using Lesson_58_HT.Repository;

namespace Lesson_58_HT.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHostingEnvironment env;

        public AdminController(IHostingEnvironment env)
        {
            this.env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product, IFormFile productImg)
        {
           

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
                return View(product);
            }

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            ProductRepository.AddProduct(product);
            return RedirectToAction("Index", "Admin");

        }

        public IActionResult Update()
        {
            return View(ProductRepository.GetProducts());
        }

        public IActionResult Delete()
        {
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
