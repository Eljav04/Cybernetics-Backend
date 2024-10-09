using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson_49_HT.Services.AutoIncremnet;
using MyColection.Generic;

namespace Lesson_49_HT.Model
{
    internal class Contact
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public static readonly MyList<string> Properties = new()
        {
            "Name", "Surname", "Phone number"
        };

        public Contact()
        {       
        }
        public Contact(string name, string surname, string phonenumber)
        {
            ID = AutoIncrement.GetUserId();
            Name = name;
            Surname = surname;
            PhoneNumber = phonenumber;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"" +
                $"Contact ID: {ID}\n" +
                $" Name: {Name}\n " +
                $" Surname: {Surname}\n " +
                $" Phone number: {PhoneNumber}\n " +
                "=========================="
                );
        }

    }
}
