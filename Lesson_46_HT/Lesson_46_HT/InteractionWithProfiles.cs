using System.Collections;
using System.Text.RegularExpressions;
using Registration;
using AdditionalTools.Messages;

namespace VehicleSpace
{
    public class InteractionWithProfiles
    {
        // Creating new profileControllers for interact with any profiles list
        public UsersController usersController;
        public AdminController adminController;
        public InteractionWithProfiles()
        {
            usersController = new UsersController();
            adminController = new AdminController();
        }

        // Main Functionality

        // Sign Up function
        public bool SignUp(ref int new_userID)
        {
            ArrayList new_userRef = new();

            if(usersController.CreateProfile(ref new_userRef))
            {
                /*
                 Creting newProfile in ArryList. Then converting from ArrayList to Profile class and
                 adding it to ProfileData
                 */
                Profile new_user = UsersController.ConvertToProfile(new_userRef);
                usersController.AddUser(new_user);

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
        public bool SignIn(ref int userID, ref Profile CheckProfile)
        {
            Console.Clear();
            Console.WriteLine("Enter your Email: ");
            string? inputEmail = Console.ReadLine();

            Console.Write("Enter your Password: ");
            string? inputPassword = Console.ReadLine();

            // Check if email is coorect
            Profile currentProfile;

            // Initial search profile among admins and then among users
            int current_user_id = usersController.FindUserIDbyEmail(inputEmail);
            int current_admin_id = adminController.FindUserIDbyEmail(inputEmail);

            if (current_admin_id != 0)
            {
                currentProfile = adminController.GetUserById(current_admin_id);
            }
            else if (current_user_id != 0)
            {
                currentProfile = usersController.GetUserById(current_user_id);
            }
            else {
                return false;
            }
            

            // Check if Password is correct
            if (currentProfile.CheckPassword(inputPassword))
            {
                // return user id
                userID = currentProfile.Id;
                CheckProfile = currentProfile;
                return true;
            }
            return false;
        }

        // CheckMyPasswordFunc
        public bool CheckMyPassword(int userID)
        {
            Profile profile;

            if (usersController.IfExistID(userID)){
                profile = usersController.GetUserById(userID);
            }
            else
            {
                profile = adminController.GetUserById(userID);
            }
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
                usersController.DeleteById(userID);
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
                if (usersController.IfExistID(userID))
                {
                    usersController.UpdateByID(userID);
                }
                else
                {
                    adminController.UpdateByID(userID);
                }
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
            usersController.ShowAllProfilesInfo();
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
            usersController.ShowAllProfilesInfo();
            Console.Write("Enter the id of user which you want to remove: ");

            // Check if input string only contain numeric charecters
            string? input_value = Console.ReadLine();
            Regex num_regex = new Regex((string)Profile.CheckPatterns["Age"]);
            if (num_regex.IsMatch(input_value))
            {
                int enter_id = Convert.ToInt32(input_value);
                if (usersController.DeleteById(enter_id))
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
            usersController.ShowAllProfilesInfo();
            Console.Write("Enter the id of user which profile propertties you want to update: ");

            // Check if input string only contain numeric charecters
            string? input_value = Console.ReadLine();
            Regex num_regex = new Regex((string)Profile.CheckPatterns["Age"]);
            if (num_regex.IsMatch(input_value))
            {
                int enter_id = Convert.ToInt32(input_value);

                // Check if if ProfileData exist profile with entered ID
                if (usersController.IfExistID(enter_id))
                {
                    usersController.UpdateByID(enter_id);
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