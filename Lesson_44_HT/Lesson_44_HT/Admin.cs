using System;
namespace Lesson_44_HT
{
	public class Admin : Profile
	{
        public Admin() : base()
        {
        }
        public Admin(
            string userName,
            string userSurname,
            string userEmail,
            string userPassword,
            int userid) : base(
                UserRole.Admin,
                userName,
                userSurname,
                userEmail,
                userPassword,
                userid)
        {
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine(
                $"Email: {Email}\n" +
                "======================"
                );
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
                    if (UpdateEmail(new_prop))
                    {
                        isChangable = true;
                    }
                    break;
                case "4":
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

