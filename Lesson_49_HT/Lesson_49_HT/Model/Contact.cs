using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson_49_HT.Services.Patterns;
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

        public bool UpdateName(string new_value)
        {
            if (Patterns.RE_name.IsMatch(new_value))
            {
                Name = new_value;
                return true;
            }
            return true;
        }

        public bool UpdateSurname(string new_value)
        {
            if (Patterns.RE_surname.IsMatch(new_value))
            {
                Name = new_value;
                return true;
            }
            return true;
        }

        public bool UpdatePhonenumber(string new_value)
        {
            if (Patterns.RE_phone_number.IsMatch(new_value))
            {
                Name = new_value;
                return true;
            }
            return true;
        }

        public bool Update(string new_value, string choosen_option)
        {
            switch (choosen_option)
            {
                case "1":
                    if (UpdateName(new_value))
                    {
                        return true;
                    }
                    return false;
                case "2":
                    if (UpdateSurname(new_value))
                    {
                        return true;
                    }
                    return false;
                case "3":
                    if (UpdatePhonenumber(new_value))
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }



    }
}
