using System;
using Lesson_56_HT.Models;


namespace Lesson_56_HT.Repositories
{
	public static class UserRequestRepository
	{
		public static List<User> UserRequestList = new();
	

		public static void AddUser(User user)
		{
			UserRequestList.Add(user);
		}
	}
}

