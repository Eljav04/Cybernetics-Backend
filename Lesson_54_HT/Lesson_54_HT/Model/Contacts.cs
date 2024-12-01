using System;
using Lesson_54_HT.Services.Patterns;

namespace Lesson_54_HT.Model
{
	public class Contacts
	{
		public int ID { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        public int ProfileID { get; set; }

        public Contacts()
		{
		}

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {ID}\n" +
                              $"Name: {Name}");
            if (!Patterns.CheckIsNullable(Surname))
            {
                Console.WriteLine($"Surname: {Surname}");
            }

            Console.WriteLine("Number(s): ");
            this.PhoneNumbers.ForEach(n => Console.WriteLine($"\t{n}"));


            if (!Patterns.CheckIsNullable(Email))
            {
                Console.WriteLine($"Email: {Email}");
            }
            if (!Patterns.CheckIsNullable(Website))
            {
                Console.WriteLine($"Website: {Website}");
            }

            Console.WriteLine("=================================");




        }
	}
}

