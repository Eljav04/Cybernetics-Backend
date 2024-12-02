using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_54_HT.Services.Messages
{
    public static class Errors
    {
        private static void ShowError(string errorText)
        {
            Console.Clear();
            Console.WriteLine(errorText);
            Console.ReadKey();
            Console.Clear();
        }

        private static Dictionary<string, string> ErrorCodes = new()
        {
                {"tryAgain_txt", "\nPlease try again!"},

                {"error10",  "You chose nonexistent option" },

                {"error100",  "ID is not correct" },
                {"error101",  "Name is not correct" },
                {"error102",  "Surname is not correct" },
                {"error103",  "Phone number is not correct" },
                {"error104",  "Email is not correct" },
                {"error105",  "Website is not correct" },

                {"error149",  "Name can't be null" },
                {"error150",  "Name, Phone number or Password can't be null" },


                {"error110",  "Passwors must have minimum 8 characters" },
                {"error111",  "Password must have at least 1 number" },
                {"error112",  "Passwoed must have at least 1 UpperCase character" },


                {"error200",  "Can not properly connect to database" },
                {"error300",  "Nothing could be found for the entered value" },


                {"error400",  "You choose nonaccessable ID" },

                {"error500",  "This profle already exist!" },
                {"error501",  "This profle can not found!" },
                {"error502",  "Login or email is not correct!" },




            };

        // Show mistake error and interrupt implementing a process


        public static void ShowErrorByErrorCode(int error_code)
        {

            string errorText = ErrorCodes[$"error{error_code}"]
                             + ErrorCodes[$"tryAgain_txt"];
            ShowError(errorText);

        }
        public static void LogginInMistake()
        {
            string errorText = "Login or password is not correct!\nPlease try again!";
            ShowError(errorText);
        }

        public static void MistakeError()
        {
            string errorText = "You have a mistake! Please try again";
            ShowError(errorText);
        }

        // Show that choosen option is nonexistent and interrupt implementing a process
        public static void NonexistentOptionError()
        {
            string errorText = "You chose nonexistent option\n" + "Try again!";
            ShowError(errorText);
        }

    }
}
