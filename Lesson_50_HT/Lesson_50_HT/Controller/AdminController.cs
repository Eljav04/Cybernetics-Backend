using System;
using Lesson_50_HT.Model;
namespace Lesson_50_HT.Controller
{
	internal class AdminController
	{
		public List<Admin> AdminsList { get; set; }

		public AdminController()
		{
			AdminsList = new();
		}

		public void Add(Admin new_admin)
		{
			AdminsList.Add(new_admin);
		}

		public bool DeleteByID(int admin_id)
		{
			foreach (Admin admin in AdminsList)
			{
				if (admin.ID == admin_id)
				{
					AdminsList.Remove(admin);
					return true;
				}
			}
			return false;
		}


	}
}

