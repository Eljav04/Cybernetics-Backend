using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson_49_HT.Model;
using MyColection.Generic;

namespace Lesson_49_HT.Controller.Interfaces
{
    internal interface IContactControler
    {
        public MyList<Contact> ContactList { get; set; }

        public void ShowAllInfo();
        public void AddContact(Contact new_contact);
        public bool DeleteContact(int contactID);
        public bool IfExist(int contactID);
        public Contact? GetContactByID(int contactID);
    }
}
