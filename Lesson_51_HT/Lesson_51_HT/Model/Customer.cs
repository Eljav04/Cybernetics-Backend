using System;
using Lesson_51_HT.Services.Autoincrement;

namespace Lesson_51_HT.Model
{
	public class Customer
	{
        public int ID { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Product> ProductsList { get; set; }

        public Customer(
            string Name,
            string Surname,
            string Email,
            string Password,
            List<Product> ProductsList
        )
        {
            this.ID = Autoincrement.GetCustomerID();
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.Password = Password;
            this.ProductsList = ProductsList;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"User Info: \n" +
                $"ID: {ID}\n" +
                $"Name: {Name}\n" +
                $"Surname: {Surname}\n" +
                $"Email: {Email}\n" +
                $"Password: {Password}\n"+
                $"=============================");
        }
    }
}

