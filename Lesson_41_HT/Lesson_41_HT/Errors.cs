using System;
namespace Errors_Class
{
    public class Errors
    {
        public void ShowError(string errorText)
        {
            Console.Clear();
            Console.WriteLine(errorText);
            Console.ReadKey();
            Console.Clear();
        }
        // Show mistake error and interrupt implementing a process
        public void MistakeError()
        {
            string errorText = "You have a mistake! Please try again";
            ShowError(errorText);
        }

        // Show that choosen option is nonexistent and interrupt implementing a process
        public void NonexistentOptionError()
        {
            string errorText = "You chose nonexistent option\n" + "Try again!";
            ShowError(errorText);
        }

        // Show that required product сouldn't find in Product list
        public void ProductFindError()
        {
            string errorText = "Couldn't find the required product\n" + "Try again!";
            ShowError(errorText);
        }

        // Show that Not enough products left
        public void NotEnoughCount()
        {
            string errorText = "Not enough products left. Couldn't sell the required product\n" + "Try again!";
            ShowError(errorText);
        }
    }
}
