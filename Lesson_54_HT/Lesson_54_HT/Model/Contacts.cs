using System;
namespace Lesson_54_HT.Model
{
	public class Contacts
	{
		public int ID { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        public int ProfileID { get; set; }

        public Contacts()
		{
		}
	}
}

