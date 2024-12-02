using System;
using Lesson_54_HT.Services.Patterns;

namespace Lesson_54_HT.Model
{
	public class Profile
	{
        public int ID { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Profile()
		{
		}

        public void ShowInfo()
        {
            Console.WriteLine("Your profile: \n");
            Console.WriteLine($"ID: {ID}\n" +
                              $"Name: {Name}");
            if (!Patterns.CheckIsNullable(Surname))
            {
                Console.WriteLine($"Surname: {Surname}");
            }

            Console.WriteLine($"Phone number: {Surname}");

            if (!Patterns.CheckIsNullable(Email))
            {
                Console.WriteLine($"Email: {Email}");
            }

            Console.WriteLine("=================================");

        }

    }
}

