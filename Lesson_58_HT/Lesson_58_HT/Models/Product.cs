using System.ComponentModel.DataAnnotations;
using Lesson_58_HT.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_58_HT.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z0-9_+#№][a-zA-Z0-9_+#№\s]+$", ErrorMessage = "Product's name is not correct")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Quantity is reqired")]
        [Range(0, 1000000, ErrorMessage = "Quantity must be between 0 and 1.000.000") ]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is reqired")]
        [Range(0.01, 1000000, ErrorMessage = "Quantity must be between 0.01 and 1.000.000")]
        public decimal Price { get; set; }

        public string? Image { get; set; }

        public int CategoryID { get; set; }

        public Product()
        {
        }

        public Product(
            string Name,
            int Quantity,
            decimal Price,
            string Image,
            int CategoryID
            )
        {
            this.ID = Autoincrement.GetProductID();
            this.Name = Name;
            this.Quantity = Quantity;
            this.Price = Price;
            this.Image = Image;
            this.CategoryID = CategoryID;
        }



    }
}
