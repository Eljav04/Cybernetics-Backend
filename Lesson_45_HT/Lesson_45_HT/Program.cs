using System;
using System.Collections;
using Lesson_45_HT;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Classes
{
    public class Program
    {
        public static void Main()
        {
            InteractionWithProfiles IWP = new();
            // Creating and adding admin user
            Admin admin_profile = new Admin(
                "Admin", "Admin", "admin@gmail.com","admin1234", 1);
            IWP.profileController.AddUser(admin_profile);

            // Creating and adding some example users
            IWP.profileController.AddUser(
                new User("Nazim", "Jeyhunov", 25, "example@gmail.com", "1234", 2));

            IWP.profileController.AddUser(
                new User("Amina", "Aliyeva", 28, "amina_aliyeva@gmail.com", "amina5678", 3));

            IWP.profileController.AddUser(
                new User("Kamran", "Qasimov", 30, "kamran_qasimov@gmail.com", "kamran9101", 4));

            IWP.profileController.AddUser(
                new User("Leyla", "Mammadova", 22, "leyla_mammadova@gmail.com", "leyla1123", 5));


            LaunchProgram();

            void LaunchProgram()
            {
                bool isContinue = true;

                while (isContinue)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to our site! Please registrate or sign in your account");
                    Console.WriteLine(
                        "1. Sign Up\n" +
                        "2. Sign In\n" +
                        "3. Quit");

                    Console.Write("Choose option: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            SignUpFunc();
                            break;
                        case "2":
                            SignInFunc();
                            break;
                        case "3":
                            isContinue = false;
                            break;
                        default:
                            Errors.NonexistentOptionError();
                            break;
                    }
                }
            }

            void SignUpFunc()
            {
                int new_userID = 0;
                if (IWP.SignUp(ref new_userID))
                {
                    LoggingInAsUser(new_userID);
                }
                else
                {
                    Errors.MistakeError();
                }
            }

            void SignInFunc()
            {
                int userID = 0;
                if (IWP.SignIn(ref userID))
                {
                    Profile checkProfile = IWP.profileController.GetUserById(userID);
                    if (checkProfile.IfUserIsAdmin()){
                        LoggingInAsAdmin(userID);
                    }
                    else {
                        LoggingInAsUser(userID);
                    }
                }
                else
                {
                    Errors.MistakeError();
                }
            }

            // Loggging in as a User
            void LoggingInAsUser(int userID){
                Profile currentUser = IWP.profileController.GetUserById(userID);

                bool isContinue = true;
                while (isContinue)
                {
                    Console.Clear();
                    Console.WriteLine(
                        "Your account info: \n"+
                        "======================"
                        );

                    // Show User info
                    currentUser.ShowInfo();

                    // Action part
                    Console.WriteLine("What do you want to do?\n"+
                            "1. Update\n" +
                            "2. Remove my profile\n" +
                            "3. Quit");

                    Console.Write("Choose option: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            IWP.UpdateMyProfile(userID);
                            break;
                        case "2":
                            if (IWP.DeleteMyProfile(userID)){                       
                                isContinue = false;
                            };
                            break;
                        case "3":
                            isContinue = false;
                            break;
                        default:
                            Errors.NonexistentOptionError();
                            break;
                    }

                }

            }

            // Logging in as a Admin
            void LoggingInAsAdmin(int userID)
            {
                Profile currentUser = IWP.profileController.GetUserById(userID);

                bool isContinue = true;
                while (isContinue)
                {
                    Console.Clear();
                    Console.WriteLine(
                        "Your account info: \n" +
                        "======================"
                        );

                    // Show User info
                    currentUser.ShowInfo();

                    // Action part
                    Console.WriteLine("What do you want to do?\n" +
                            "1. Show all profiles\n" +
                            "2. Update user profile\n" +
                            "3. Update my profile\n" +
                            "4. Delete user profile\n" +
                            "5. Quit");

                    Console.Write("Choose option: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            IWP.ShowAllProfilesFunc(userID);
                            break;
                        case "2":
                            IWP.UpddateProfile(userID);
                            break;
                        case "3":
                            IWP.UpdateMyProfile(userID);
                            break;
                        case "4":
                            IWP.DeleteProfile(userID);
                            break;
                        case "5":
                            isContinue = false;
                            break;
                        default:
                            Errors.NonexistentOptionError();
                            break;
                    }

                }

            }

        }
    }
}