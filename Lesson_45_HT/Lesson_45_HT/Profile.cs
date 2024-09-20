using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson_45_HT
{
    public class Profile
    {
        // Profiles properties
        public UserRole Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }

        // 2 Ways to create profile object
        public Profile() { }
        public Profile(UserRole userRole,
            string userName,
            string userSurname,
            string userEmail,
            string userPassword,
            int userid)
        {
            Role = userRole;
            Name = userName;
            Surname = userSurname;
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
        public virtual void ShowInfo()
        {
            Console.Write(
                $"User ID: {Id}\n"+
                $"UserRole: {Role}\n" +
                $"Name: {Name}\n"+
                $"Surname: {Surname}\n"
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

        // Common empty Update function
        public virtual void Update(string choosen_prop, string new_prop)
        {
        }

        
    }
}
