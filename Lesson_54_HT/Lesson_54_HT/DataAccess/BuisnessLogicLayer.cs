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

		public int AddContact(Contacts contact)
		{
			if (contact.Name is null)
			{
				return 100;
			}

			if (!Patterns.RE_name.IsMatch(contact.Name))
			{
				return 101;
			}

			if (contact.Surname is not null
                && !Patterns.RE_surname.IsMatch(contact.Surname))
			{
				return 102;
			}

			foreach (string number in contact.PhoneNumbers)
			{
				if (!Patterns.RE_email.IsMatch(number))
                {
                    return 103;
                }
            }

            if (contact.Email is not null
                && !Patterns.RE_email.IsMatch(contact.Email))
            {
                return 104;
            }

            if (contact.Website is not null
            && Uri.IsWellFormedUriString(contact.Website, UriKind.RelativeOrAbsolute))
			{
                return 105;
            }

            return DLL.AddContact(contact);

		}
	}
}

