using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_54_HT.Services.Messages
{
    internal static class Message
    {
        public static void ShowMessage(string messageText)
        {
            Console.WriteLine(messageText);
        }

        public static readonly string PushKey = "\nPush any key to continue...";

        // Message that inform user about ending of some action
        public static void EndOfProcess()
        {
            string messageText = "Push any key to continue...";
            ShowMessage(messageText);
            Console.ReadKey();
        }

        public static void NewContactAdded()
        {
            string messageText = $"New contact added successfully! \n" +
                "Push any key to continue...";
            Console.Clear();
            ShowMessage(messageText);
            Console.ReadKey();
        }

        public static void ContactDeleted()
        {
            string messageText = $"Contact deleted successfully! \n" +
                "Push any key to continue...";
            Console.Clear();
            ShowMessage(messageText);
            Console.ReadKey();
        }

        public static void MistakeError()
        {
            string errorText = "You have a mistake! Please try again";
            ShowMessage(errorText);
        }

   
    }
}
