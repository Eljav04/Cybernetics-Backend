using System;
using Lesson_54_HT.DataAccess;
using Lesson_54_HT.Model;

namespace Lesson_54_HT.Controller
{
	public class ProfileController
	{
        private BuisnessLogicLayer BLL;

        public ProfileController()
		{
			BLL = new();
		}

        public int AddProfile()
        {
            Console.WriteLine("Enter name: ");
            string? name = Console.ReadLine();

            Console.WriteLine("Enter surname | For skip just push enter: ");
            string? surname = Console.ReadLine();

            Console.WriteLine("Enter phone number ");
            string? phone_number = Console.ReadLine();

            Console.WriteLine("Enter email | for skip just push enter:");
            string? email = Console.ReadLine();

            Console.WriteLine("Enter password | for skip just push enter:");
            string? password = Console.ReadLine();

            Profile profile = new()
            {
                Name = name,
                Surname = surname,
                PhoneNumber = phone_number,
                Email = email,
                Password = password
            };

            return BLL.AddProfile(profile);
        }

        public (Profile profile, int ErrorCode) GetProfile()
        {
            Console.Clear();
            Console.Write("Enter your Login\n" +
                "Your email or phone number: ");
            string Login = Console.ReadLine();

            Console.Write("Enter your Password: ");
            string Password = Console.ReadLine();

            (Profile profile, int ErrorCode) search_results = BLL.GetProfle(Login);

            if (search_results.ErrorCode.Equals(0))
            {
                if (search_results.profile.Password.Equals(Password))
                {
                    return search_results;
                }
                else
                {
                    return (search_results.profile, 502);
                }
            }
            else
            {
                return search_results;
            }

        }


    }
}

