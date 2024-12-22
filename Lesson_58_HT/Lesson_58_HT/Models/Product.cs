using System.ComponentModel.DataAnnotations;
using Lesson_58_HT.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_58_HT.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        [Display (Name = "Product")]
        public string? Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? Image { get; set; }

        public Product()
        {
        }

        public Product(
            string Name,
            int Quantity,
            decimal Price,
            string Image
            )
        {
            this.ID = Autoincrement.GetProductID();
            this.Name = Name;
            this.Quantity = Quantity;
            this.Price = Price;
            this.Image = Image;
        }



    }
}
