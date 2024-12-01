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
                {"error104",  "Email is not correct" },
                {"error105",  "Website is not correct" },

                {"error200",  "Can not properly connect to database" },
                {"error300",  "Nothing could be found for the entered value" },

                {"error400",  "You choose nonaccessable ID" }

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
