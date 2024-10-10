using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyColection.Generic;
using Lesson_49_HT.Model;
using Lesson_49_HT.Controller.Interfaces;
using Lesson_49_HT.Services.Patterns;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace Lesson_49_HT.Controller
{
    internal class ContactController : IContactControler
    {
        public MyList<Contact> ContactList { get; set; }
        public ContactController(List<Contact> list) {
            ContactList = new();
            foreach (var item in list)
            {
                ContactList.Add(item);
            }
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

        public static void ShowAllInfo(List<Contact> required_list)
        {
            foreach (Contact conatct in required_list)
            {
                conatct.ShowInfo();
            }
        }

        public static void ShowAllInfo(MyList<Contact> required_list)
        {
            foreach (Contact conatct in required_list)
            {
                conatct.ShowInfo();
            }
        }

        public void AddContact(Contact new_contact)
        {
            ContactList.Add(new_contact);
        }

        public static Contact ConvertToContact(MyList<string> list)
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
            foreach (string prop in Contact.Properties)
            {
                Console.Write($"Enter {prop}: ");
                string? current_value = Console.ReadLine();

                Regex current_regex = new Regex(Patterns.CheckPatterns[prop]);
                if (current_regex.IsMatch(current_value))
                {
                    new_contact.Add(current_value);
                }
                else
                {
                    return null;
                };
            }
            return new_contact;
        }

        public bool DeleteContact(int contactID)
        {
            foreach (Contact contact in ContactList)
            {
                if (contact.ID == contactID)
                {
                    ContactList.Remove(contact);
                    return true;
                }
            }
            return false;
        }

        public bool IfExist(int contactID)
        {
            foreach (Contact contact in ContactList)
            {
                if (contact.ID.Equals(contactID))
                {
                    return true;
                }
            }
            return false;
        }

        public Contact? GetContactByID(int contactID)
        {
            foreach (Contact contact in ContactList)
            {
                if (contact.ID == contactID)
                {
                    return contact;
                }
            }
            return null;
        }

        public List<Contact> GetContactByName(string contact_name)
        {
            return ContactList.Where<Contact>(c => c.SearchByName(contact_name)).ToList();

        }
        public List<Contact> GetContactBySurname(string contact_surname)
        {
            return (List<Contact>)ContactList.Where<Contact>(c => c.SearchBySurname(contact_surname)).ToList();
        }

        public List<Contact> GetContactByPhoneNumber(string contact_number)
        {
            return (List<Contact>)ContactList.Where<Contact>(c => c.SearchByPhoneNumber(contact_number)).ToList();
        }



    }
}
