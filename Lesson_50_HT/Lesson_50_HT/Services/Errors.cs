using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_50_HT.Services.Messages
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
        public static void LogginInMistake()
        {
            string errorText = "Login or password is not correct!\n Please try again";
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

        // Show that required product сouldn't find in Product list
        public static void StudentFindError()
        {
            string errorText = "Couldn't find the required student\n" + "Try again!";
            ShowError(errorText);
        }
        public static void CategoryFindError()
        {
            string errorText = "Couldn't find the required category\n" + "Try again!";
            ShowError(errorText);
        }

        public static void QuestionFindError()
        {
            string errorText = "Couldn't find the required question\n" + "Try again!";
            ShowError(errorText);
        }




    }
}
