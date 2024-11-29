using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_54_HT.Services.Messages
{
    public static class Errors
    {
        public static void ShowError(string errorText)
        {
            Console.Clear();
            Console.WriteLine(errorText);
            Console.ReadKey();
            Console.Clear();
        }

        
        // Show mistake error and interrupt implementing a process


        public static void AddContactError(int error_code)
        {

            Dictionary<string, string> ErrorByCode = new()
            {
                {"tryAgain_txt", "\nPlease try again!"},

                {"error100",  "Name or phone number can't be null" },
                {"error101",  "Name is not correct" },
                {"error102",  "Surname is not correct" },
                {"error103",  "Phone number is not correct" },
                {"error104",  "Email is not correct" },
                {"error105",  "Website or phone number can't be nul" },

                {"error200",  "Can not properly connect to database" }
            };

            string errorText = ErrorByCode[$"error{error_code}"]
                             + ErrorByCode[$"tryAgain_txt"];
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
