using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson_44_HT
{
    public class InteractionWithProfiles
    {
        // Creating new profileController for interact with profiles list
        public ProfileController profileController;
        public InteractionWithProfiles()
        {
            profileController = new ProfileController();
        }

        // Main Functionality

        // Sign Up function
        public bool SignUp(ref int new_userID)
        {
            ArrayList new_userRef = new();

            if(profileController.CreateProfile(ref new_userRef))
            {
      
                /*
                 Creting newProfile in ArryList. Then converting from ArrayList to Profile class and
                 adding it to ProfileData
                 */
                Profile new_user = ProfileController.ConvertToProfile(new_userRef);
                profileController.AddUser(new_user);

                Console.Clear();
                Console.WriteLine("You successfully sign up at our site!");
                Console.WriteLine("Push any key to continue...");
                Console.ReadKey();

                // Return via ref id of new user
                new_userID = new_user.Id;
                return true;
            };
            return false;
        }

        // SignIn function
        public bool SignIn(ref int userID)
        {
            Console.Clear();
            Console.WriteLine("Enter your Email: ");
            string? inputEmail = Console.ReadLine();

            Console.Write("Enter your Password: ");
            string? inputPassword = Console.ReadLine();

            // Check if email is coorect
            int current_id = profileController.FindUserIDbyEmail(inputEmail);
            if (current_id == 0) {
                return false;
            }
            Profile currentProfile = profileController.GetUserById(current_id);

            // Check if Password is correct
            if (currentProfile.CheckPassword(inputPassword))
            {
                // return user id
                userID = current_id;
                return true;
            }
            return false;
        }

        // CheckMyPasswordFunc
        public bool CheckMyPassword(int userID)
        {
            Profile profile = profileController.GetUserById(userID);
            Console.Clear();
            Console.WriteLine("Enter password: ");
            if (profile.CheckPassword(Console.ReadLine())){
                return true;
            }
            Errors.WrongPassword();
            return false;
        }

        // Users' functions
        // DeleteMyProfile function
        public bool DeleteMyProfile(int userID)
        {
            if (CheckMyPassword(userID))
            {
                profileController.DeleteById(userID);
                Console.Clear();
                Console.WriteLine("Your profile is deleted succesfully");
                Console.WriteLine("Push any key to continue...");
                Console.ReadKey();
                return true;
            }
            return false;
        }

        // UpdateMyProfile function
        public void UpdateMyProfile(int userID)
        {
            if (CheckMyPassword(userID))
            {
                profileController.UpdateByID(userID);
            }
        }

        // Admin's functions
        // ShowAllProfilesFunc
        public void ShowAllProfilesFunc(int adminID)
        {
            if (!CheckMyPassword(adminID))
            {
                // End inmplementation if password is wrong
                return;
            }

            Console.Clear();
            profileController.ShowAllProfilesInfo();
            Console.WriteLine("Push any key to continue...");
            Console.ReadKey();
        }

        //DeleteProfile function
        public void DeleteProfile(int adminID)
        {
            if (!CheckMyPassword(adminID))
            {
                // End inmplementation if password is wrong
                return;
            }

            Console.Clear();
            // Show all profiles for choose
            profileController.ShowAllProfilesInfo();
            Console.Write("Enter the id of user which you want to remove: ");

            // Check if input string only contain numeric charecters
            string? input_value = Console.ReadLine();
            Regex num_regex = new Regex((string)Profile.CheckPatterns["Age"]);
            if (num_regex.IsMatch(input_value))
            {
                int enter_id = Convert.ToInt32(input_value);
                if (profileController.DeleteById(enter_id))
                {
                    Console.Clear();
                    Console.WriteLine("This profile is deleted succesfully");
                    Console.WriteLine("Push any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Errors.UserFindError();
                };
            }
            else
            {
                Errors.NonexistentOptionError();
                return;
            };
        }

        //DeleteProfile function
        public void UpddateProfile(int adminID)
        {
            if (!CheckMyPassword(adminID))
            {
                // End inmplementation if password is wrong
                return;
            }

            Console.Clear();
            // Show all profiles for choose
            profileController.ShowAllProfilesInfo();
            Console.Write("Enter the id of user which profile propertties you want to update: ");

            // Check if input string only contain numeric charecters
            string? input_value = Console.ReadLine();
            Regex num_regex = new Regex((string)Profile.CheckPatterns["Age"]);
            if (num_regex.IsMatch(input_value))
            {
                int enter_id = Convert.ToInt32(input_value);

                // Check if if ProfileData exist profile with entered ID
                if (profileController.IfExistID(enter_id))
                {
                    profileController.UpdateByID(enter_id);
                }
                else
                {
                    Errors.UserFindError();
                };
            }
            else
            {
                Errors.NonexistentOptionError();
                return;
            };
        }
    }
}