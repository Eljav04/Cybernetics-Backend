﻿using System;
using Lesson_55_HT.DAL;

namespace Lesson_55_HT.Repository
{
	public class ContactRepository
	{
        public List<Contact> ContactsList { get; set; }

  //      public ContactRepository()
		//{
  //          ContactsList = new()
  //          {
  //              new Contact()
  //              {
  //                  ID = 1,
  //                  Name = "Yusif",
  //                  Surname = "Beybutov",
  //                  Location = "Local storage",
  //                  Email = "yusif@gmail.com",
  //                  PhoneNumber = "+994503431290"
  //              },
  //              new Contact()
  //              {
  //                  ID = 2,
  //                  Name = "Aylin",
  //                  Surname = "Hasanova",
  //                  Location = "Google account",
  //                  Email = "aylin@gmail.com",
  //                  PhoneNumber = "+994503221478"
  //              },
  //              new Contact()
  //              {
  //                  ID = 3,
  //                  Name = "Emin",
  //                  Surname = "Mammadov",
  //                  Location = "iCloud",
  //                  Email = "emin@gmail.com",
  //                  PhoneNumber = "+994502589634"
  //              },
  //              new Contact()
  //              {
  //                  ID = 4,
  //                  Name = "Leyla",
  //                  Surname = "Aliyeva",
  //                  Location = "SIM card",
  //                  Email = "leyla@gmail.com",
  //                  PhoneNumber = "+994504478123"
  //              },
  //              new Contact()
  //              {
  //                  ID = 5,
  //                  Name = "Nigar",
  //                  Surname = "Guliyeva",
  //                  Location = "Local storage",
  //                  Email = "nigar@gmail.com",
  //                  PhoneNumber = "+994507856341"
  //              },
  //              new Contact()
  //              {
  //                  ID = 6,
  //                  Name = "Murad",
  //                  Surname = "Karimov",
  //                  Location = "Google account",
  //                  Email = "murad@gmail.com",
  //                  PhoneNumber = "+994505432876"
  //              },
  //              new Contact()
  //              {
  //                  ID = 7,
  //                  Name = "Rashad",
  //                  Surname = "Ibrahimov",
  //                  Location = "iCloud",
  //                  Email = "rashad@gmail.com",
  //                  PhoneNumber = "+994508731245"
  //              },
  //              new Contact()
  //              {
  //                  ID = 8,
  //                  Name = "Sabina",
  //                  Surname = "Huseynova",
  //                  Location = "SIM card",
  //                  Email = "sabina@gmail.com",
  //                  PhoneNumber = "+994502147893"
  //              },
  //              new Contact()
  //              {
  //                  ID = 9,
  //                  Name = "Kamran",
  //                  Surname = "Aliyev",
  //                  Location = "Local storage",
  //                  Email = "kamran@gmail.com",
  //                  PhoneNumber = "+994509845312"
  //              }

  //          };

  //      }

		public ContactRepository()
		{
            using var DbContex = new AppDbContext();
			ContactsList = DbContex.Contacts.ToList();
        }


        public Contact? GetByID(int id) => ContactsList.FirstOrDefault(c => c.ContactId == id);

	}
}

