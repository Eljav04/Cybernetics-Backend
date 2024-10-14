using System;
using Lesson_50_HT.Services.AutoIncrement;
using Lesson_50_HT.Services.RandomGenerator;

namespace Lesson_50_HT.Model
{
	internal class Student
	{
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Category { get; set; }

        public static readonly List<string> Properties = new()
        {
            "Name", "Surname", "Login"
        };


        public Student()
        {
            ID = AutoIncrement.GetStudentID();
        }

        public Student(
            string name,
            string surname,
            string login,
            int category_id
            )
        {
            ID = AutoIncrement.GetAdminID();
            Name = name;
            Surname = surname;
            Login = login;
            Password = RandomGenerator.GeneratePassword();
            Category = category_id;
        }

        public void ShowInfo()
        {
            Console.WriteLine(
                $"User ID: {ID}\n" +
                $"Name: {Name}\n" +
                $"Surname: {Surname}\n" +
                $"Login: {Login}\n" +
                $"Password: {Password}\n" +
                $"Category ID: {Category}\n" +
                "=========================="
                );
        }
	}
}

