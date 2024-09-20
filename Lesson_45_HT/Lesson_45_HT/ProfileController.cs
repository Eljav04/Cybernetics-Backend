using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Lesson_45_HT
{
    public class ProfileController
    {
        // Creating List that contain all profiles of users
        public List<Profile> ProfilesData { get; set; }

        // Profiles properties
        public ArrayList UserProperties = new() {
                "Name", "Surname", "Age", "Email", "Password"
            };

        // Profiles properties
        public ArrayList AdminProperties = new() {
                "Name", "Surname", "Email", "Password"
            };

        // Intitial user_id for first profile, wihich will increase after every creating
        private static int user_id = 6;

        public ProfileController()
        {
            ProfilesData = new();
        }

        // Create user function 
        public bool CreateProfile(ref ArrayList new_profile)
        {
            Console.Clear();
            foreach (string property in UserProperties)
            {
                Console.Write($"Enter {property}: ");
                string? current_value = Convert.ToString(Console.ReadLine());

                Regex regex = new Regex((string)Profile.CheckPatterns[property]);
                if (regex.IsMatch(current_value))
                {
                    new_profile.Add(current_value);
                }
                else
                {
                    return false;
                };
            }
            return true;
        }

        // ConvertToProfile function by entered ArrayList
        public static Profile ConvertToProfile(ArrayList profile_ref)
        {
            return new User()
            {
                Role = UserRole.User,
                Name = profile_ref[0].ToString(),
                Surname = profile_ref[1].ToString(),
                Age = Convert.ToInt32(profile_ref[2]),
                Email = profile_ref[3].ToString(),
                Password = profile_ref[4].ToString(),
                Id = user_id++
            };
        }

        // Add user function
        public void AddUser(Profile new_profile)
        {
            ProfilesData.Add(new_profile);
        }

        // Find User function
        public int FindUserIDbyEmail(string inputEmail)
        {
            foreach (Profile profile in ProfilesData)
            {
                if (profile.Email.Equals(inputEmail)){
                    return profile.Id;
                }
            }
            return 0;
        }

        // Get User by Id function
        public Profile GetUserById(int id)
        {
            Profile empty_profile = new();
            foreach (Profile profile in ProfilesData)
            {
                if (profile.Id.Equals(id)){
                    return profile;
                }
            }
            return empty_profile;
        }

        // Show all profiles function
          public void ShowAllProfilesInfo()
        {
            foreach (Profile profile in ProfilesData)
            {
                if (profile.Role.Equals(UserRole.User))
                {
                    profile.ShowInfo();
                }
            }
        }

        // Delete function
        public bool DeleteById(int userID)
        {
            foreach (Profile profile in ProfilesData)
            {
                // Check if userRole equal User (not admin)
                if (profile.Role == UserRole.User)
                {
                    if (profile.Id == userID)
                    {
                        ProfilesData.Remove(profile);
                        return true;
                    }
                }
            }
            return false;
        }

        // UpdateById function
        public void UpdateByID(int userID)
        {
            ArrayList Properties;
            Profile uptadted_profile = GetUserById(userID);

            // Change propertis depend on userRole
            if (uptadted_profile.IfUserIsAdmin()){
                Properties = AdminProperties;
            }
            else{
                Properties = UserProperties;
            }

            Console.Clear();
            Console.WriteLine("What do you want to change?");
            for (int i = 0; i < Properties.Count; i++)
            {
                Console.WriteLine($"{i+1}. Update {Properties[i]}");
            }
            
            Console.Write("Choose option: ");
            string? choosen_opt = Console.ReadLine();

            Console.Write($"Enter new property : ");
            string? new_prop = Console.ReadLine();

            uptadted_profile.Update(choosen_opt, new_prop);

        }

        public bool IfExistID(int userID)
        {
            foreach (Profile profile in ProfilesData)
            {
                // Check if userRole equal User (not admin)
                if (profile.Role == UserRole.User)
                {
                    if (profile.Id == userID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
