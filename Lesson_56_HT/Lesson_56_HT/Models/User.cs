using System;
using Lesson_56_HT.Enums;

namespace Lesson_56_HT.Models
{
	public class User
	{
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int Budjet { get; set; }
        public int CityID { get; set; }

        public User(
            string fullname,
            string email,
            string phonenumber,
            int bufjet,
            int cityID
            )
        {
            FullName = fullname;
            Email = email;
            PhoneNumber = phonenumber;
            Budjet = bufjet;
            CityID = cityID;
        }


        public User()
        {
        }

    }
}
