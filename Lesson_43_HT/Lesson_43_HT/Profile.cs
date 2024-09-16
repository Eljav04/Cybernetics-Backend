using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson_43_HT
{
    public class Profile
    {
        // Profiles properties
        public UserRole Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }

        // 2 Ways to create profile object
        public Profile() { }
        public Profile(UserRole userRole,
            string userName,
            string userSurname,
            int userAge,
            string userEmail,
            string userPassword,
            int userid)
        {
            Role = userRole;
            Name = userName;
            Surname = userSurname;
            Age = userAge;
            Email = userEmail;
            Password = userPassword;
            Id = userid;
        }

        //Patterns for Brand / Model / Price / Quantity
        public readonly static Hashtable CheckPatterns = new(){
            {"Name", @"^[a-zA-Z]+$" },
            {"Surname", @"^[a-zA-Z]+$" },
            {"Age", @"^[0-9]+$" },
            {"Email", @"^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}" },
            {"Password", @"^[A-Za-z0-9._%-@#&*]+$" }
        };

        // Main functionality
        public void ShowInfo()
        {
            Console.WriteLine(
                $"User ID: {Id}\n"+
                $"UserRole: {Role}\n" +
                $"Name: {Name}\n"+
                $"Surname: {Surname}\n" +
                $"Age: {Age}\n" +
                $"Email: {Email}\n" +
                "======================"
                );
        }

        public bool CheckPassword(string input_password)
        {
            if (input_password.Equals(Password))
            {
                return true;
            }
            return false;
        }

        public bool IfUserIsAdmin()
        {
            if (Role.Equals(UserRole.Admin))
            {
                return true;
            }
            return false;
        }

        // Updtade functions for every property separetly
        public bool UpdateName(string new_name)
        {
            Regex new_regex = new Regex((string)CheckPatterns["Name"]);
            if (new_regex.IsMatch(new_name))
            {
                Name = new_name;
                return true;
            }
            return false;
        }

        public bool UpdateSurname(string new_surname)
        {
            Regex new_regex = new Regex((string)CheckPatterns["Surname"]);
            if (new_regex.IsMatch(new_surname))
            {
                Surname = new_surname;
                return true;
            }
            return false;
        }

        public bool UpdateAge(string new_age)
        {
            Regex new_regex = new Regex((string)CheckPatterns["Age"]);
            if (new_regex.IsMatch(new_age))
            {
                Age = Convert.ToInt32(new_age);
                return true;
            }
            return false;
        }

        public bool UpdateEmail(string new_email)
        {
            Regex new_regex = new Regex((string)CheckPatterns["Email"]);
            if (new_regex.IsMatch(new_email))
            {
                Email = new_email;
                return true;
            }
            return false;
        }

        public bool UpdatePassword(string new_password)
        {
            Regex new_regex = new Regex((string)CheckPatterns["Password"]);
            if (new_regex.IsMatch(new_password))
            {
                Password = new_password;
                return true;
            }
            return false;
        }

        // Common Update function with ability to choose require property

        public void Update(string choosen_prop, string new_prop)
        {
            bool isChangable = false;
            switch (choosen_prop)
            {
                case "1":
                    if (UpdateName(new_prop)){
                        isChangable = true;
                    }
                    break;
                case "2":
                    if (UpdateSurname(new_prop)){
                        isChangable = true;
                    }
                    break;
                case "3":
                    if (UpdateAge(new_prop)){
                        isChangable = true;
                    }
                    break;
                case "4":
                    if (UpdateEmail(new_prop)){
                        isChangable = true;
                    }
                    break;
                case "5":
                    if (UpdatePassword(new_prop)){
                        isChangable = true;
                    }
                    break;
                default:
                    Errors.NonexistentOptionError();
                    return;
            }

            // Check if input new_prop is written in properer way
            if (isChangable)
            {
                Console.WriteLine("Property successfully changed!");
                Console.WriteLine("Push any key to continue...");
                Console.ReadLine();
            }
            else {
                Errors.MistakeError();
            };
        }
    }
}
