using System.ComponentModel.DataAnnotations;

namespace Lesson_58_HT.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? Image { get; set; }

    }
}
