using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Lesson_45_HT
{
	public class AdminController : ProfileController
	{
        // Creating List that contain all profiles of users
        public override List<Profile> ProfilesData { get; set; }

        // User Profiles properties
        public ArrayList Properties = new() {
                "Name", "Surname", "Email", "Password"
            };

        public AdminController()
        {
            ProfilesData = new();
        }

        // Add user function
        public override void AddUser(Profile new_profile)
        {
            ProfilesData.Add(new_profile);
        }

        // Find User function
        public override int FindUserIDbyEmail(string inputEmail)
        {
            foreach (Profile profile in ProfilesData)
            {
                if (profile.Email.Equals(inputEmail))
                {
                    return profile.Id;
                }
            }
            return 0;
        }

        // Get User by Id function
        public override Profile GetUserById(int id)
        {
            Profile empty_profile = new();
            foreach (Profile profile in ProfilesData)
            {
                if (profile.Id.Equals(id))
                {
                    return profile;
                }
            }
            return empty_profile;
        }

        // UpdateById function
        public override void UpdateByID(int userID)
        {
            Profile uptadted_profile = GetUserById(userID);

            Console.Clear();
            Console.WriteLine("What do you want to change?");
            for (int i = 0; i < Properties.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Update {Properties[i]}");
            }

            Console.Write("Choose option: ");
            string? choosen_opt = Console.ReadLine();

            Console.Write($"Enter new property : ");
            string? new_prop = Console.ReadLine();

            uptadted_profile.Update(choosen_opt, new_prop);

        }
    }
}

