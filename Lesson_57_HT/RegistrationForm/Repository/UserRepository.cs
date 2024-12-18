using System;
using RegistrationForm.Models;

namespace RegistrationForm.Repository
{
	public static class UserRepository
	{
		private static List<User> users = new List<User>()
		{
			new User() { Name = "Yusif", Lastname = "Husyenli", Email = "huseynliy@gmail.com", Participate = true},
            new User() { Name = "Yusif", Lastname = "Husyenli", Email = "huseynliy@gmail.com", Participate = true},
            new User() { Name = "Yusif", Lastname = "Husyenli", Email = "huseynliy@gmail.com", Participate = true}
        };

		public static List<User> GetUsers()
		{
			return users;
		}

		public static void AddUser(User user)
		{
			users.Add(user);
		}
	}
}

