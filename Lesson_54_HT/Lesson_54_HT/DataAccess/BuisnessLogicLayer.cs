using System;
using Lesson_54_HT.Model;
using System.Text.RegularExpressions;
using Lesson_54_HT.Services.Patterns;
using Lesson_54_HT.DataAccess;

namespace Lesson_54_HT.DataAccess
{
	public class BuisnessLogicLayer
	{
		private DataLogicLayer DLL;

		public BuisnessLogicLayer()
		{
            DLL = new();
		}

        // Add Functions
		public int AddContact(Contacts contact)
		{
			if (contact.Name is null || contact.Name.Equals(""))
			{
				return 100;
			}

			if (!Patterns.RE_name.IsMatch(contact.Name))
			{
				return 101;
			}

			if (contact.Surname is not null
				&& contact.Surname != ""
                && !Patterns.RE_surname.IsMatch(contact.Surname))
			{
				return 102;
			}

			if (contact.PhoneNumbers.Count < 1)
			{
				return 103;
			}

			foreach (string number in contact.PhoneNumbers)
			{
				if (!Patterns.RE_phone_number.IsMatch(number))
                {
                    return 103;
                }
            }

            if (contact.Email is not null
                && contact.Email != ""
                && !Patterns.RE_email.IsMatch(contact.Email))
            {
                return 104;
            }

            if (contact.Website is not null
				&& contact.Website != ""
                && !Uri.IsWellFormedUriString(contact.Website, UriKind.Absolute))
			{
                return 105;
            }

            return DLL.AddContact(contact);

		}

        // Show and Get Functions
        public void ShowAllContacts()
        {
            List<Contacts> checkList = DLL.GetAllContacts();
            checkList.ForEach(c => c.ShowInfo());
        }


        public (int ErrorCode, List<Contacts> ContactsList)
            GetContactsBy(string contact_category, string search_parametr)
		{
            if (contact_category == "ID"
                && !Patterns.RE_numeric.IsMatch(search_parametr))
            {
                return (100, null);
            }
             
            if (contact_category == "Name"
                && !Patterns.RE_name.IsMatch(search_parametr))
            {
                return (101, null);
            }

            if (contact_category == "Surname"
                && !Patterns.RE_surname.IsMatch(search_parametr))
            {
                return (102, null);
            }

            if (contact_category == "Email"
                && !Patterns.RE_email.IsMatch(search_parametr))
            {
                return (104, null);
            }

            if (contact_category == "Website"
                && !Uri.IsWellFormedUriString(search_parametr, UriKind.Absolute))
            {
                return (105, null);
            }

            List<Contacts>? search_results = DLL.GetAllContactsBy(contact_category, search_parametr);
            if (search_results is null)
            {
                return (200, null);
            }
            else if(search_results.Count < 1)
            {
                return (300, null);
            }
            else
            {
                return (0, search_results);
            }
        }

        // Delete functions
        public int DeleteContact(int delete_id, List<Contacts> contactsList)
        {
            List<int> DeleteAviliableIDs
                    = contactsList.Select(c => c.ID).ToList();

            if (!DeleteAviliableIDs.Contains(delete_id))
            {
                return 400;
            }

            return DLL.DeleteContact(delete_id);
        }

        // Update Function
        public int UpdateContact(string contact_category, string update_parametr, Contacts update_contact)
        {
            if (contact_category == "Name"
                && !Patterns.RE_name.IsMatch(update_parametr))
            {
                return 101;
            }
            else
            {
                update_contact.Name = update_parametr;
            }

            if (contact_category == "Surname"
                && !Patterns.RE_surname.IsMatch(update_parametr))
            {
                return 102;
            }
            else
            {
                update_contact.Surname = update_parametr;
            }

            if (contact_category == "Email"
                && !Patterns.RE_email.IsMatch(update_parametr))
            {
                return 104;
            }
            else
            {
                update_contact.Email = update_parametr;
            }

            if (contact_category == "Website"
                && !Uri.IsWellFormedUriString(update_parametr, UriKind.Absolute))
            {
                return 105;
            }
            else
            {
                update_contact.Website = update_parametr;
            }

            List<Contacts>? search_results = DLL.GetAllContactsBy(contact_category, update_parametr);
            if (search_results is null)
            {
                return (200, null);
            }
            else if (search_results.Count < 1)
            {
                return (300, null);
            }
            else
            {
                return (0, search_results);
            }
        }
    }
}

