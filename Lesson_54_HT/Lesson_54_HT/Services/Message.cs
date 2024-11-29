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

        public static void NewCategoryAdded()
        {
            string messageText = $"New category added successfully! \n" +
                "Push any key to continue...";
            Console.Clear();
            ShowMessage(messageText);
            Console.ReadKey();
        }

        public static void NewQuestionAdded()
        {
            string messageText = $"New question added successfully! \n" +
                "Push any key to continue...";
            Console.Clear();
            ShowMessage(messageText);
            Console.ReadKey();
        }

        public static void StudentDeleted()
        {
            string messageText = $"Student deleted successfully! \n" +
                "Push any key to continue...";
            Console.Clear();
            ShowMessage(messageText);
            Console.ReadKey();
        }

        public static void CategoryDeleted()
        {
            string messageText = $"Category deleted successfully! \n" +
                "Push any key to continue...";
            Console.Clear();
            ShowMessage(messageText);
            Console.ReadKey();
        }

        public static void QuestiionDeleted()
        {
            string messageText = $"Question deleted successfully! \n" +
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

        public static void ExamStarted()
        {
            string errorText = "Before beginning the exam you must read and confirm all rules.\n" +
            "The exam will last 60 minutes. Every question has a bunch of answers. You should choose ONLY ONE.\n" +
            "For start just push enter...";
            Console.Clear();
            ShowMessage(errorText);
            Console.ReadKey();
        }

        

    }
}
