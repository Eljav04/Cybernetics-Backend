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

        // Profiles functions

        public int AddProfile(Profile profile)
        {
            if (profile.Name is null || profile.Name.Equals("")
                || profile.PhoneNumber is null || profile.PhoneNumber.Equals("")
                || profile.Password is null || profile.Password.Equals(""))
            {
                return 150;
            }


            if (!Patterns.RE_name.IsMatch(profile.Name))
            {
                return 101;
            }

            if (profile.Surname is not null
                && profile.Surname != ""
                && !Patterns.RE_surname.IsMatch(profile.Surname))
            {
                return 102;
            }

            if (!Patterns.RE_phone_number.IsMatch(profile.PhoneNumber))
            {
                return 103;
            }


            if (profile.Email is not null
                && profile.Email != ""
                && !Patterns.RE_email.IsMatch(profile.Email))
            {
                return 104;
            }

            if (!Patterns.RE_password_hasMinimum8Chars.IsMatch(profile.Password))
            {
                return 110;
            }
            if (!Patterns.RE_password_hasNumber.IsMatch(profile.Password))
            {
                return 111;
            }
            if (!Patterns.RE_password_hasUpperChar.IsMatch(profile.Password))
            {
                return 112;
            }

            return DLL.AddProfile(profile);

        }

        public (Profile Profile, int ErrorCode) GetProfle(string login)
        {
            if (!Patterns.RE_phone_number.IsMatch(login))
            {
                if (!Patterns.RE_email.IsMatch(login))
                {
                    return (null, 502);
                }
            }

            int CheckError = DLL.CheckIfExistProfile(login, login);
            if (CheckError.Equals(200))
            {
                return (null, 200);
            }

            if (CheckError < 1)
            {
                return (null, 501);
            }

            return DLL.GetProfile(login);
        }

        // Add Functions
        public int AddContact(Contacts contact, int profile_id)
		{
			if (contact.Name is null || contact.Name.Equals(""))
			{
				return 149;
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

            return DLL.AddContact(contact, profile_id);

		}

        // Show and Get Functions
        public void ShowAllContacts(int profile_id)
        {
            List<Contacts> checkList = DLL.GetAllContacts(profile_id);
            checkList.ForEach(c => c.ShowInfo());
        }

        public (int ErrorCode, List<Contacts> ContactsList)
            GetContactsBy(string contact_category, string search_parametr, int profile_id)
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

            List<Contacts>? search_results = DLL.GetAllContactsBy(contact_category, search_parametr, profile_id);
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
            if (contact_category == "Name")
            {
                if (!Patterns.RE_name.IsMatch(update_parametr))
                {
                    return 101;

                }
                update_contact.Name = update_parametr;
            }

            if (contact_category == "Surname")
            {
                if (!Patterns.RE_surname.IsMatch(update_parametr))
                {
                    return 102;

                }
                update_contact.Surname = update_parametr;
            }

            if (contact_category == "Email")
            {
                if (!Patterns.RE_email.IsMatch(update_parametr))
                {
                    return 104;

                }
                update_contact.Email = update_parametr;
            }

            if (contact_category == "Website")
            {
                if (!Patterns.RE_website.IsMatch(update_parametr))
                {
                    return 105;

                }
                update_contact.Website = update_parametr;
            }

            return DLL.UpdateContact(update_contact);
        }

        public int UpdateContactNumbers(int contact_id, string old_number, string new_number)
        {
            if (!Patterns.RE_phone_number.IsMatch(new_number))
            {
                return 103;

            }

            return DLL.UpdateNumber(contact_id, old_number, new_number);
            
        }
    }
}

