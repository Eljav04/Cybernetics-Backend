using System;
using Lesson_50_HT.Services.AutoIncrement;

namespace Lesson_50_HT.Model
{
	internal class Admin
	{
		public int ID { get; private set; }
        public string Name { get; set; }
		public string Surname { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }

        public Admin()
		{
			ID = AutoIncrement.GetAdminID();
		}

        public Admin(
			string name,
            string surname,
            string login,
            string password
            )
        {
            ID = AutoIncrement.GetAdminID();
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
        }

        public void ShowInfo()
        {
            Console.WriteLine(
                $"Admin ID: {ID}\n" +
                $"Name: {Name}\n" +
                $"Surname: {Surname}\n" +
                $"Login: {Login}\n" +
                "=========================="
                );
        }
    }
}

