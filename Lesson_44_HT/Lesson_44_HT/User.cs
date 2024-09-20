using System;
using System.Text.RegularExpressions;

namespace Lesson_44_HT
{
	public class User : Profile
	{
		// User properties that specified only for that class
        public int Age { get; set; }

        public User() : base()
		{
		}
        public User(
            string userName,
            string userSurname,
            int userAge,
            string userEmail,
            string userPassword,
            int userid) : base(
                UserRole.User,
                userName,
                userSurname,
                userEmail,
                userPassword,userid)
        {
            Age = userAge;
        }

        // Main functionality
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine(
                $"Age: {Age}\n" +
                $"Email: {Email}\n" +
                "======================"
                );
        }

        // Updtade function for age separetly
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

        // Common Update function with ability to choose require property

        public override void Update(string choosen_prop, string new_prop)
        {
            bool isChangable = false;
            switch (choosen_prop)
            {
                case "1":
                    if (UpdateName(new_prop))
                    {
                        isChangable = true;
                    }
                    break;
                case "2":
                    if (UpdateSurname(new_prop))
                    {
                        isChangable = true;
                    }
                    break;
                case "3":
                    if (UpdateAge(new_prop))
                    {
                        isChangable = true;
                    }
                    break;
                case "4":
                    if (UpdateEmail(new_prop))
                    {
                        isChangable = true;
                    }
                    break;
                case "5":
                    if (UpdatePassword(new_prop))
                    {
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
            else
            {
                Errors.MistakeError();
            };
        }


    }
}

