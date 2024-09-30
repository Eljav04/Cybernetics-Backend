using System;
using System.Collections;
using VehicleSpace;
using Registration;
using AdditionalTools.Messages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Classes
{
    public class Program
    {
        public static void Main()
        {
            InteractionWithProfiles IWP = new();
            InteractionWithVehicles IWV = new();

            // Crateing and adding default profiles/vehicles
            AddDefaultProfiles();
            AddDefaultCars();
            AddDefaultMotos();
            AddDefaultTrucks();

            LaunchProgram();

            // Main part the project, which start infinite getting and preprocessing promts
            void LaunchProgram()
            {
                bool isContinue = true;

                while (isContinue)
                {
                    Console.Clear();
                    Console.WriteLine(
                        "Welcome to our site! Please registrate or sign in your account");
                    Console.WriteLine(
                        "1. Sign Up\n" +
                        "2. Sign In\n" +
                        "3. Guest mode\n" +
                        "4. Quit");

                    Console.Write("Choose option: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            SignUpFunc();
                            break;
                        case "2":
                            SignInFunc();
                            break;
                        case "3":
                            IWV.VehicleSearchGuest();
                            Message.EndOfProcess();
                            break;
                        case "4":
                            isContinue = false;
                            break;
                        default:
                            Errors.NonexistentOptionError();
                            break;
                    }
                }
            }

            // SignUp/In functions
            void SignUpFunc()
            {
                int new_userID = 0;
                if (IWP.SignUp(ref new_userID))
                {
                    LoggingInAsUser(new_userID);
                }
                else
                {
                    Errors.MistakeError();
                }
            }

            void SignInFunc()
            {
                int userID = 0;
                Profile checkProfile = new();
                if (IWP.SignIn(ref userID, ref checkProfile))
                {
                    if (checkProfile.IfUserIsAdmin()) {
                        LoggingInAsAdmin(userID);
                    }
                    else {
                        LoggingInAsUser(userID);
                    }
                }
                else
                {
                    Errors.MistakeError();
                }
            }

            // Loggging in as a User
            void LoggingInAsUser(int userID) {
                User currentUser = (User)IWP.usersController.GetUserById(userID);

                bool isContinue = true;
                while (isContinue)
                {
                    Console.Clear();
                    Console.WriteLine(
                        "Your account info: \n" +
                        "======================"
                        );

                    // Show User info
                    currentUser.ShowInfo();

                    // Action part
                    Console.WriteLine(
                        "What do you want to do?\n" +
                            "1. Update\n" +
                            "2. Remove my profile\n" +
                            "3. Open Turbo.az\n" +
                            "4. Quit");

                    Console.Write("Choose option: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            IWP.UpdateMyProfile(userID);
                            break;
                        case "2":
                            if (IWP.DeleteMyProfile(userID)) {
                                isContinue = false;
                            };
                            break;
                        case "4":
                            isContinue = false;
                            break;
                        case "3":
                            LaunchTurboAz(currentUser);
                            isContinue = false;
                            break;
                        default:
                            Errors.NonexistentOptionError();
                            break;
                    }
                }
            }

            void LaunchTurboAz(User currentUser)
            {
                bool isContinue = true;
                while (isContinue)
                {
                    Console.Clear();
                    Console.WriteLine(
                        "[==============< ••• >============]\n\n" +
                        "\tWelcome to Turbo.az\n\n" +
                        "[==============< ••• >============]\n" +
                            "What do you want to do?\n" +
                                "\t1. Search car\n" +
                                "\t2. Show my favorities\n" +
                                "\t3. Remove from my favorities\n" +
                                "\t4. Show my vehiceles\n" +
                                "\t5. Add vehicle\n" +
                                "\t6. Update vehicle\n" +
                                "\t7. Remove vehicle\n" +
                                "\t8. Quit"
                                );

                    Console.Write("Choose option: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            IWV.VehicleSearch(currentUser);
                            break;
                        case "2":
                            Console.Clear();
                            currentUser.ShowFavorites();
                            Message.EndOfProcess();
                            break;
                        case "3":
                            Console.Clear();
                            IWV.RemoveFromFavorities(currentUser);
                            break;
                        case "4":
                            Console.Clear();
                            currentUser.ShowMyVehicles();
                            Message.EndOfProcess();
                            break;
                        case "5":
                            IWV.VehcicleAdd(currentUser);
                            break;
                        case "6":
                            IWV.UpdateVehicle(currentUser);
                            break;
                        case "7":
                            Console.Clear();
                            IWV.RemoveVehicle(currentUser);
                            break;
                        case "8":
                            isContinue = false;
                            break;
                        default:
                            Errors.NonexistentOptionError();
                            break;
                    }
                }
            }

            // Logging in as a Admin
            void LoggingInAsAdmin(int userID)
            {
                Profile currentUser = IWP.adminController.GetUserById(userID);

                bool isContinue = true;
                while (isContinue)
                {
                    Console.Clear();
                    Console.WriteLine(
                        "Your account info: \n" +
                        "======================"
                        );

                    // Show User info
                    currentUser.ShowInfo();

                    // Action part
                    Console.WriteLine("What do you want to do?\n" +
                            "1. Show all profiles\n" +
                            "2. Update user profile\n" +
                            "3. Update my profile\n" +
                            "4. Delete user profile\n" +
                            "5. Quit");

                    Console.Write("Choose option: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            IWP.ShowAllProfilesFunc(userID);
                            break;
                        case "2":
                            IWP.UpddateProfile(userID);
                            break;
                        case "3":
                            IWP.UpdateMyProfile(userID);
                            break;
                        case "4":
                            IWP.DeleteProfile(userID);
                            break;
                        case "5":
                            isContinue = false;
                            break;
                        default:
                            Errors.NonexistentOptionError();
                            break;
                    }

                }

            }

            void AddDefaultProfiles()
            {
                // Creating and adding admin user
                Admin admin_profile = new Admin(
                    "Admin", "Admin", "admin@gmail.com", "admin1234", 1);
                IWP.adminController.AddUser(admin_profile);

                // Creating and adding some example users
                IWP.usersController.AddUser(
                    new User("Nazim", "Jeyhunov", 25, "example@gmail.com", "1234", 2));

                IWP.usersController.AddUser(
                    new User("Amina", "Aliyeva", 28, "e@mail.ru", "1234", 3));

                IWP.usersController.AddUser(
                    new User("Kamran", "Qasimov", 30, "kamran_qasimov@gmail.com", "kamran9101", 4));

                IWP.usersController.AddUser(
                    new User("Leyla", "Mammadova", 22, "leyla_mammadova@gmail.com", "leyla1123", 5));
            }

            void AddDefaultCars()
            {
                Random rand = new Random();

                // Create 200 random cars
                for (int i = 0; i < 200; i++)
                {
                    // Randomly select a brand
                    string brand = Car.carBrands[rand.Next(Car.carBrands.Count)];

                    // Randomly select a model from the Hashtable based on the brand
                    ArrayList models = (ArrayList)Car.carModels[brand];
                    string model = (string)models[rand.Next(models.Count)];

                    // Generate random price and mileage
                    decimal price = rand.Next(5000, 200000);
                    int mileage = rand.Next(0, 300000);    

                    // Add the car to the list
                    Car car = new Car(brand, model, price, mileage);
                    IWV.carController.AddVehicle(car);
                }
            }

            void AddDefaultMotos()
            {
                Random rand = new Random();

                // Create 200 random motocycles
                for (int i = 0; i < 200; i++)
                {
                    // Randomly select a brand
                    string brand = Moto.motoBrands[rand.Next(Moto.motoBrands.Count)];

                    // Randomly select a model from the Hashtable based on the brand
                    ArrayList models = (ArrayList)Moto.motoModels[brand];
                    string model = (string)models[rand.Next(models.Count)];

                    // Generate random price and mileage
                    decimal price = rand.Next(5000, 200000);
                    int mileage = rand.Next(0, 300000);

                    // Add the car to the list
                    Moto moto = new Moto(brand, model, price, mileage);
                    IWV.motoController.AddVehicle(moto);
                }
            }

            void AddDefaultTrucks()
            {
                Random rand = new Random();

                // Create 200 random motocycles
                for (int i = 0; i < 200; i++)
                {
                    // Randomly select a brand
                    string brand = Truck.truckBrands[rand.Next(Truck.truckBrands.Count)];

                    // Randomly select a model from the Hashtable based on the brand
                    ArrayList models = (ArrayList)Truck.truckModels[brand];
                    string model = (string)models[rand.Next(models.Count)];

                    // Generate random price and mileage
                    decimal price = rand.Next(5000, 200000);
                    int mileage = rand.Next(0, 300000);

                    // Add the car to the list
                    Truck truck = new Truck(brand, model, price, mileage);
                    IWV.truckController.AddVehicle(truck);
                }
            }


        }
    }
}