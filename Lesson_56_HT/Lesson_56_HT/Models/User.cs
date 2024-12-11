using System;
using Lesson_56_HT.Enums;

namespace Lesson_56_HT.Models
{
	public class User
	{
        public int ID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int Budjet { get; set; }
        public City CityID { get; set; }

        public User(int id,
            string fullname,
            string email,
            string phonenumber,
            int bufjet,
            City cityID
            )
        {
            ID = id;
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

