using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_43_HT
{
    public class Profile
    {
        public UserRole Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Profile() { }
        public Profile(UserRole userRole,
            string userName,
            string userSurname,
            int userAge,
            string userEmail,
            string userPassword)
        {
            Role = userRole;
            Name = userName;
            Surname = userSurname;
            Age = userAge;
            Email = userEmail;
            Password = userPassword;
        }


        public void ShowInfo(int id)
        {
            Console.WriteLine(
                $"User ID: {id}\n"+
                $"UserRole: {Role}\n" +
                $"Name: {Name}\n"+
                $"Surname: {Surname}\n" +
                $"Age: {Age}\n" +
                $"Email: {Email}\n" +
                "======================"
                );
        }

        public bool ChechPassword(string input_password)
        {
            if (input_password.Equals(Password))
            {
                return true;
            }
            return false;
        }

    }
}
