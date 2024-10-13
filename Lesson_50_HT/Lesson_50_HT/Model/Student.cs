using System;
using Lesson_50_HT.Services.AutoIncrement;
using Lesson_50_HT.Services.PasswordGenerator;

namespace Lesson_50_HT.Model
{
	internal class Student
	{
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public int Password { get; set; }
        public string Category { get; set; }

        public Student()
        {
            ID = AutoIncrement.GetStudentID();
        }

        public Student(
            string name,
            string surname,
            string login
            )
        {
            ID = AutoIncrement.GetAdminID();
            Name = name;
            Surname = surname;
            Login = login;
            Password = PasswordGenerator.GeneratePassword();
        }

        public void ShowInfo()
        {
            Console.WriteLine(
                $"User ID: {ID}\n" +
                $"Name: {Name}\n" +
                $"Surname: {Surname}\n" +
                $"Login: {Login}\n" +
                $"Password: {Password}\n" +
                "=========================="
                );
        }
	}
}

