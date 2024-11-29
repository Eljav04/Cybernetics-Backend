using System;
using Lesson_54_HT.DataAccess;
using Lesson_54_HT.Model;

namespace Lesson_54_HT.Controller
{
	public class ContactController
	{
        private BuisnessLogicLayer BLL;
		public ContactController()
		{
            BLL = new();
		}

		public int AddContact()
		{
			Console.WriteLine("Enter name: ");
			string? name = Console.ReadLine();

            Console.WriteLine("Enter surname | For skip just push enter: ");
            string? surname = Console.ReadLine();

            
            string? phone_number;
            List<string> numbers = new();
            do
            {
                Console.WriteLine("Enter phone numbers | " +
                "For stop enter 0");
                phone_number = Console.ReadLine();
                numbers.Add(phone_number);
            }
            while (phone_number != "0");


            Console.WriteLine("Enter email | for skip just push enter:");
            string? email = Console.ReadLine();

            Console.WriteLine("Enter website | for skip just push enter:");
            string? website = Console.ReadLine();

            Contacts contact = new()
            {
                Name = name,
                Surname = surname,
                PhoneNumbers = numbers,
                Email = email,
                Website = website
            };

            return BLL.AddContact(contact);
        }
    }
}

