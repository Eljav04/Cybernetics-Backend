using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTools.Messages
{
    public static class Message
    {
        public static void ShowMessage(string messageText)
        {
            Console.WriteLine(messageText);
        }
        // Message that inform user about ending of some action
        public static void EndOfProcess()
        {
            string messageText = "Push any key to continue...";
            ShowMessage(messageText);
            Console.ReadKey();
        }

     

        // Message that inform user about ending of some action
        public static void ChooseVehicle()
        {
            string messageText =
                "Choose type of vehicle\n" +
                "1.Car \n" +
                "2.Motorcycle \n" +
                "3.Truck \n";
            Console.Clear();
            ShowMessage(messageText);
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
            string messageText = $"New contact deleted successfully! \n" +
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
