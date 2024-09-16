using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_43_HT
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

        // Show that required product сouldn't find in Product list
        public static void UserFindError()
        {
            string errorText = "Couldn't find the required user profile\n" + "Try again!";
            ShowError(errorText);
        }

        // Show that input password is wrong
        public static void WrongPassword()
        {
            string errorText = "Password is wrong!\n" + "Try again!";
            ShowError(errorText);
        }



    }
}
