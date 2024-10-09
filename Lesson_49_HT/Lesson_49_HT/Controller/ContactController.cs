using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyColection.Generic;
using Lesson_49_HT.Model;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace Lesson_49_HT.Controller
{
    internal class ContactController
    {
        public MyList<Contact> ContactList { get; set; }
        public ContactController() {
            ContactList = new();
        }

        public void ShowAllInfo()
        {
            Console.WriteLine("Contacts Info: ");
            Console.WriteLine("==========================");
            foreach (Contact conatct in ContactList)
            {
                conatct.ShowInfo();
            }
        }

        public void AddContact(Contact new_contact)
        {
            ContactList.Add(new_contact);
        }


        public Contact ConvertToContact(MyList<string> list)
        {
            return new Contact(
                list[0],
                list[1],
                list[2]);
        }

        public MyList<string> CreateContact()
        {
            Console.Clear();
            MyList<string> new_contact = new();
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter {Contact.Properties[0]}: ");
                string? current_value = Console.ReadLine();

                Regex current_regex = new Regex(CheckPatterns[i]);
                if (regex.IsMatch(current_value))
                {
                    new_contact[i] = current_value;
                }
                else
                {
                    goto MistakeError;
                };
            };
        }

    }
}
