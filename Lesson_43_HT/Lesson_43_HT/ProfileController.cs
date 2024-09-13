using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Lesson_43_HT
{
    public class ProfileController
    {
        // Creating ArrayList that contain all profiles of users
        public ArrayList ProfilesData { get; set; }
        public ArrayList Properties =
            [
                "Name", "Surname", "Age", "Email", "Password"
            ];
        public ProfileController()
        {
            ProfilesData = new();
        }

        //Patterns for Brand / Model / Price / Quantity
        private Hashtable CheckPatterns = new(){
            {"Name", @"^[a-zA-Z]+$" },
            {"Surname", @"^[a-zA-Z]+$" },
            {"Age", @"^[0-9]+$" },
            {"Email", @"^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}" },
            {"Password", @"^[A-Za-z0-9._%-@#&*]+$" }
        };
        

        // Delete function
        public bool DeleteById(int userID)
        {
            if (userID < ProfilesData.Count && userID >= 0)
            {
                Profile current_profile = (Profile)ProfilesData[userID];
                // Check if userRole equal User (not admin)
                if (current_profile.Role == UserRole.User)
                {
                    ProfilesData.RemoveAt(userID);
                }
                return true;
            }
            return false;
        }

        // Show all profiles function
        public void ShowAllProfilesInfo()
        {
            int counter = 0;
            foreach (Profile profile in ProfilesData)
            {
                profile.ShowInfo(counter++);
            }
        }

        // ConvertToProfile function by entred ArrayList
        public Profile ConvertToProfile(ArrayList profile_ref)
        {
            return new Profile()
            {
                Role = UserRole.User,
                Name = profile_ref[0].ToString(),
                Surname = profile_ref[1].ToString(),
                Age = Convert.ToInt32(profile_ref[2]),
                Email = profile_ref[3].ToString(),
                Password = profile_ref[4].ToString()
            };
        }

        // Add user function
        public void AddUser(Profile new_profile)
        {
            ProfilesData.Add(new_profile);
        }

        // Create user function 
        public bool CreateProfile(ref ArrayList new_profile)
        {
            Console.Clear();
            foreach (string property in Properties)
            {
                Console.Write($"Enter {property}: ");
                string? current_value = Convert.ToString(Console.ReadLine());

                Regex regex = new Regex((string)CheckPatterns[property]);
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
    }
}
