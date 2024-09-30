using System;
using System.Collections;
using AdditionalTools.AutoIncremnet;
using AdditionalTools.Messages;
using System.Text.RegularExpressions;
using Registration;

namespace VehicleSpace
{
	public partial class InteractionWithVehicles
	{
        public CarController carController;
        public MotoController motoController;
        public TruckController truckController;

        public InteractionWithVehicles()
		{
			carController = new();
            motoController = new();
            truckController = new();
		}

        public void VehicleSearchGuest()
        {
            Message.ChooseVehicle();
            switch (Console.ReadLine())
            {
                case "1":
                    Car_Search();
                    break;
                case "2":
                    Moto_Search();
                    break;
                case "3":
                    Truck_Search();
                    break;
                default:
                    Errors.NonexistentOptionError();
                    break;
            }
        }

        public void VehicleSearch(User user)
        {
            Message.ChooseVehicle();
            switch (Console.ReadLine())
            {
                case "1":
                    Car_Search();
                    Car_AddToFavorite(user);
                    break;
                case "2":
                    Moto_Search();
                    Moto_AddToFavorite(user);
                    break;
                case "3":
                    Truck_Search();
                    Truck_AddToFavorite(user);
                    break;
                default:
                    Errors.NonexistentOptionError();
                    break;
            }
        }

        public void VehcicleAdd(User user)
        {
            Message.ChooseVehicle();
            switch (Console.ReadLine())
            {
                case "1":
                    IVehicle new_car = new Car();
                    if (carController.CreateVehicle(ref new_car))
                    {
                        carController.AddVehicle(new_car);
                        user.AddMyVehcile(new_car);
                        Message.NewVehicleAdded();
                    }
                    else
                    {
                        Errors.MistakeError();
                    }
                    break;
                case "2":
                    IVehicle new_moto = new Moto();
                    if (motoController.CreateVehicle(ref new_moto))
                    {
                        motoController.AddVehicle(new_moto);
                        user.AddMyVehcile(new_moto);
                        Message.NewVehicleAdded();
                    }
                    else
                    {
                        Errors.MistakeError();
                    }
                    break;
                case "3":
                    IVehicle new_truck = new Truck();
                    if (truckController.CreateVehicle(ref new_truck))
                    {
                        truckController.AddVehicle(new_truck);
                        user.AddMyVehcile(new_truck);
                        Message.NewVehicleAdded();
                    }
                    else
                    {
                        Errors.MistakeError();
                    }
                    break;
                default:
                    Errors.NonexistentOptionError();
                    break;
            }
        }

        public void RemoveFromFavorities(User user)
        {
            user.ShowFavorites();
            Console.Write("Enter vehicle ID for remove: ");
            string? enteredValue = Console.ReadLine();
            Regex num_regex = new Regex(AutoIncrement.Numeric);
            if (!num_regex.IsMatch(enteredValue))
            {
                Errors.MistakeError();
                return;
            }

            int enterID = Convert.ToInt32(enteredValue);
            if (user.RemoveFromFavorites(enterID))
            {
                Message.VehicleRemovedFormFav(enterID);
            }
            else
            {
                Errors.MistakeError();
            }
        }

        public void RemoveVehicle(User user)
        {
            user.ShowMyVehicles();
            Console.Write("Enter vehicle ID for remove: ");
            string? enteredValue = Console.ReadLine();
            Regex num_regex = new Regex(AutoIncrement.Numeric);
            if (!num_regex.IsMatch(enteredValue))
            {
                Errors.MistakeError();
                return;
            }

            int enterID = Convert.ToInt32(enteredValue);
            if (user.RemoveFromMyVehicles(enterID))
            {
                carController.RemoveVehicle(enterID);
                motoController.RemoveVehicle(enterID);
                truckController.RemoveVehicle(enterID);
                user.RemoveFromFavorites(enterID);
                Message.VehicleRemoved(enterID);
            }
            else
            {
                Errors.MistakeError();
            }
        }

        public void UpdateVehicle(User user)
        {
            Console.Clear();
            // Show all vehicls for choose
            user.ShowMyVehicles();
            Console.Write("Enter the id of user which profile propertties you want to update: ");

            // Check if input string only contain numeric charecters
            string? input_value = Console.ReadLine();
            Regex num_regex = new Regex(AutoIncrement.Numeric);
            if (num_regex.IsMatch(input_value))
            {
                int enter_id = Convert.ToInt32(input_value);

                // Check if if ProfileData exist profile with entered ID
                if (user.IfExistVehicleID(enter_id))
                {
                    if (carController.IfExistID(enter_id))
                    {
                        carController.UpdateByID(enter_id);
                    }
                    else if (motoController.IfExistID(enter_id))
                    {
                        motoController.UpdateByID(enter_id);
                    }
                    else if (truckController.IfExistID(enter_id))
                    {
                        truckController.UpdateByID(enter_id);
                    }
                }
                else
                {
                    Errors.VehicleFindError();
                };
            }
            else
            {
                Errors.NonexistentOptionError();
                return;
            };
        }
    }

    // Car Section
    public partial class InteractionWithVehicles
    {
		// All functions that releted to cars
		public void CarShowAll() {
            Console.Clear();
			Console.WriteLine("Cars list: "); 
			carController.ShowAll();
            Message.EndOfProcess();
        }

        // Main car search function
		public bool Car_Search()
		{
            List<string> ChoosenOptionsList = new();
            List<IVehicle> CurrentCarsList = new(carController.VehiclesData);

            //created for proper choose model depend on choosen brand
            string ChoosenBrand = "None";

            while (true)
			{

                Console.Clear();
                Console.WriteLine("How you want to search?");
				Console.WriteLine(
					"1.Search by brand \n"+
                    "2.Search by model \n" +
                    "3.Search by price higher \n" +
                    "4.Search by price lower \n" +
                    "5.Search by mileage higher \n" +
                    "6.Search by mileage lower \n" +
                    "7.Show results \n" +
					"8.Quit"
                    );

                Console.Write("Choose option: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        if (ChoosenOptionsList.Contains("1"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            Console.Clear();
                            Car.ShowBrands();
                            Console.Write("Choose option: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value))
                            {
                                int enter_id = Convert.ToInt32(input_value);
                                if (enter_id >= 0 && enter_id < Car.carBrands.Count)
                                {
                                    carController.SearchByBrand(ref CurrentCarsList, Car.carBrands[enter_id]);
                                    ChoosenBrand = Car.carBrands[enter_id];
                            
                                    ChoosenOptionsList.Add("1");

                                    Message.FillterAplyedSuccessfully();
                                }
                                else
                                {
                                    Errors.NonexistentOptionError();
                                }
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "2":
                        if (ChoosenOptionsList.Contains("2"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            if (ChoosenBrand == "None")
                            {
                                Errors.ChooseBrandBefore();
                                break;
                            }

                            ArrayList models = (ArrayList)Car.carModels[ChoosenBrand];

                            Console.Clear();
                            Car.ShowModels(ChoosenBrand);
                            Console.Write("Choose option: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value))
                            {
                                int enter_id = Convert.ToInt32(input_value);
                                if (enter_id >= 0 && enter_id < models.Count)
                                {
                                    carController.SearchByModel(ref CurrentCarsList, models[enter_id].ToString());
                                    ChoosenOptionsList.Add("2");

                                    Message.FillterAplyedSuccessfully();
                                }
                                else
                                {
                                    Errors.NonexistentOptionError();
                                }
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "3":
                        if (ChoosenOptionsList.Contains("3"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Enter price: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Price);
                            Regex num_regex_2 = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value) || num_regex_2.IsMatch(input_value))
                            {
                                decimal enter_price = Convert.ToDecimal(input_value);
                                carController.SearchByPriceHigh(ref CurrentCarsList, enter_price);
                                ChoosenOptionsList.Add("3");

                                Message.FillterAplyedSuccessfully();
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "4":
                        if (ChoosenOptionsList.Contains("4"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Enter price: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Price);
                            Regex num_regex_2 = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value) || num_regex_2.IsMatch(input_value))
                            {
                                decimal enter_price = Convert.ToDecimal(input_value);
                                carController.SearchByPriceLow(ref CurrentCarsList, enter_price);
                                ChoosenOptionsList.Add("4");

                                Message.FillterAplyedSuccessfully();
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "5":
                        if (ChoosenOptionsList.Contains("5"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Enter mileage: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value))
                            {
                                int enter_mileage = Convert.ToInt32(input_value);
                                carController.SearchByMileageHigh(ref CurrentCarsList, enter_mileage);
                                ChoosenOptionsList.Add("5");

                                Message.FillterAplyedSuccessfully();
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "6":
                        if (ChoosenOptionsList.Contains("6"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Enter mileage: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value))
                            {
                                int enter_mileage = Convert.ToInt32(input_value);
                                carController.SearchByMileageLow(ref CurrentCarsList, enter_mileage);
                                ChoosenOptionsList.Add("6");

                                Message.FillterAplyedSuccessfully();
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "7":
                        Console.Clear();
                        CarController.ShowAll(CurrentCarsList);
                        return true;
                    case "8":
                        return false;
                    default:
                        Errors.NonexistentOptionError();
                        break;
                }

            }
		}

        public void Car_AddToFavorite(User currentUser)
        {
            bool isContinue = true;
            Console.WriteLine("Enter wanted ID of car to add to favorites or 0 to quit:");

            while (isContinue)
            {
                string? entered_value = Console.ReadLine();

                Regex num_regex = new Regex(AutoIncrement.Numeric);
                if (!num_regex.IsMatch(entered_value))
                {
                    Errors.MistakeError();
                    return;
                }

                int enterID = Convert.ToInt32(entered_value);
                if (enterID.Equals(0))
                {
                    return;
                }

                if (enterID < 0)
                {
                    Message.MistakeError();
                }

                IVehicle findedCar = new Car();
                if (carController.GetVehicleByID(enterID, ref findedCar))
                {
                    currentUser.AddFavorite(findedCar);
                    Message.VehicleAddedToFav(enterID);
                }
                else
                {
                    Message.MistakeError();
                }
      
            }
        }

    }

    // Moto Section
    public partial class InteractionWithVehicles
    {
        // All functions that releted to motos
        public void MotoShowAll()
        {
            Console.Clear();
            Console.WriteLine("Moto list: ");
            motoController.ShowAll();
            Message.EndOfProcess();
        }

        // Main moto search function
        public bool Moto_Search()
        {
            List<string> ChoosenOptionsList = new();
            List<IVehicle> CurrentMotosList = new(motoController.VehiclesData);

            //created for proper choose model depend on choosen brand
            string ChoosenBrand = "None";

            while (true)
            {

                Console.Clear();
                Console.WriteLine("How you want to search?");
                Console.WriteLine(
                    "1.Search by brand \n" +
                    "2.Search by model \n" +
                    "3.Search by price higher \n" +
                    "4.Search by price lower \n" +
                    "5.Search by mileage higher \n" +
                    "6.Search by mileage lower \n" +
                    "7.Show results \n" +
                    "8.Quit"
                    );

                Console.Write("Choose option: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        if (ChoosenOptionsList.Contains("1"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            Console.Clear();
                            Moto.ShowBrands();
                            Console.Write("Choose option: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value))
                            {
                                int enter_id = Convert.ToInt32(input_value);
                                if (enter_id >= 0 && enter_id < Moto.motoBrands.Count)
                                {
                                    motoController.SearchByBrand(ref CurrentMotosList, Moto.motoBrands[enter_id]);
                                    ChoosenBrand = Moto.motoBrands[enter_id];

                                    ChoosenOptionsList.Add("1");

                                    Message.FillterAplyedSuccessfully();
                                }
                                else
                                {
                                    Errors.NonexistentOptionError();
                                }
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "2":
                        if (ChoosenOptionsList.Contains("2"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            if (ChoosenBrand == "None")
                            {
                                Errors.ChooseBrandBefore();
                                break;
                            }

                            ArrayList models = (ArrayList)Moto.motoModels[ChoosenBrand];

                            Console.Clear();
                            Moto.ShowModels(ChoosenBrand);
                            Console.Write("Choose option: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value))
                            {
                                int enter_id = Convert.ToInt32(input_value);
                                if (enter_id >= 0 && enter_id < models.Count)
                                {
                                    motoController.SearchByModel(ref CurrentMotosList, models[enter_id].ToString());
                                    ChoosenOptionsList.Add("2");

                                    Message.FillterAplyedSuccessfully();
                                }
                                else
                                {
                                    Errors.NonexistentOptionError();
                                }
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "3":
                        if (ChoosenOptionsList.Contains("3"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Enter price: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Price);
                            Regex num_regex_2 = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value) || num_regex_2.IsMatch(input_value))
                            {
                                decimal enter_price = Convert.ToDecimal(input_value);
                                motoController.SearchByPriceHigh(ref CurrentMotosList, enter_price);
                                ChoosenOptionsList.Add("3");

                                Message.FillterAplyedSuccessfully();
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "4":
                        if (ChoosenOptionsList.Contains("4"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Enter price: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Price);
                            Regex num_regex_2 = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value) || num_regex_2.IsMatch(input_value))
                            {
                                decimal enter_price = Convert.ToDecimal(input_value);
                                motoController.SearchByPriceLow(ref CurrentMotosList, enter_price);
                                ChoosenOptionsList.Add("4");

                                Message.FillterAplyedSuccessfully();
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "5":
                        if (ChoosenOptionsList.Contains("5"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Enter mileage: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value))
                            {
                                int enter_mileage = Convert.ToInt32(input_value);
                                motoController.SearchByMileageHigh(ref CurrentMotosList, enter_mileage);
                                ChoosenOptionsList.Add("5");

                                Message.FillterAplyedSuccessfully();
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "6":
                        if (ChoosenOptionsList.Contains("6"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Enter mileage: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value))
                            {
                                int enter_mileage = Convert.ToInt32(input_value);
                                motoController.SearchByMileageLow(ref CurrentMotosList, enter_mileage);
                                ChoosenOptionsList.Add("6");

                                Message.FillterAplyedSuccessfully();
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "7":
                        Console.Clear();
                        MotoController.ShowAll(CurrentMotosList);
                        return true;
                    case "8":
                        return false;
                    default:
                        Errors.NonexistentOptionError();
                        break;
                }

            }
        }

        public void Moto_AddToFavorite(User currentUser)
        {
            bool isContinue = true;
            Console.WriteLine("Enter wanted ID of moto to add to favorites or 0 to quit:");

            while (isContinue)
            {
                string? entered_value = Console.ReadLine();

                Regex num_regex = new Regex(AutoIncrement.Numeric);
                if (!num_regex.IsMatch(entered_value))
                {
                    Errors.MistakeError();
                    return;
                }

                int enterID = Convert.ToInt32(entered_value);
                if (enterID.Equals(0))
                {
                    return;
                }

                if (enterID < 0)
                {
                    Message.MistakeError();
                }

                IVehicle findedMoto = new Moto();
                if (motoController.GetVehicleByID(enterID, ref findedMoto))
                {
                    currentUser.AddFavorite(findedMoto);
                    Message.VehicleAddedToFav(enterID);
                }
                else
                {
                    Message.MistakeError();
                }

            }
        }

    }

    // Truck Section
    public partial class InteractionWithVehicles
    {
        // All functions that releted to trucks
        public void TruckShowAll()
        {
            Console.Clear();
            Console.WriteLine("Trucks list: ");
            truckController.ShowAll();
            Message.EndOfProcess();
        }

        // Main truck search function
        public bool Truck_Search()
        {
            List<string> ChoosenOptionsList = new();
            List<IVehicle> CurrentTrucksList = new(truckController.VehiclesData);

            //created for proper choose model depend on choosen brand
            string ChoosenBrand = "None";

            while (true)
            {

                Console.Clear();
                Console.WriteLine("How you want to search?");
                Console.WriteLine(
                    "1.Search by brand \n" +
                    "2.Search by model \n" +
                    "3.Search by price higher \n" +
                    "4.Search by price lower \n" +
                    "5.Search by mileage higher \n" +
                    "6.Search by mileage lower \n" +
                    "7.Show results \n" +
                    "8.Quit"
                    );

                Console.Write("Choose option: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        if (ChoosenOptionsList.Contains("1"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            Console.Clear();
                            Truck.ShowBrands();
                            Console.Write("Choose option: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value))
                            {
                                int enter_id = Convert.ToInt32(input_value);
                                if (enter_id >= 0 && enter_id < Truck.truckBrands.Count)
                                {
                                    truckController.SearchByBrand(ref CurrentTrucksList, Truck.truckBrands[enter_id]);
                                    ChoosenBrand = Truck.truckBrands[enter_id];

                                    ChoosenOptionsList.Add("1");

                                    Message.FillterAplyedSuccessfully();
                                }
                                else
                                {
                                    Errors.NonexistentOptionError();
                                }
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "2":
                        if (ChoosenOptionsList.Contains("2"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            if (ChoosenBrand == "None")
                            {
                                Errors.ChooseBrandBefore();
                                break;
                            }

                            ArrayList models = (ArrayList)Truck.truckModels[ChoosenBrand];

                            Console.Clear();
                            Truck.ShowModels(ChoosenBrand);
                            Console.Write("Choose option: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value))
                            {
                                int enter_id = Convert.ToInt32(input_value);
                                if (enter_id >= 0 && enter_id < models.Count)
                                {
                                    truckController.SearchByModel(ref CurrentTrucksList, models[enter_id].ToString());
                                    ChoosenOptionsList.Add("2");

                                    Message.FillterAplyedSuccessfully();
                                }
                                else
                                {
                                    Errors.NonexistentOptionError();
                                }
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "3":
                        if (ChoosenOptionsList.Contains("3"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Enter price: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Price);
                            Regex num_regex_2 = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value) || num_regex_2.IsMatch(input_value))
                            {
                                decimal enter_price = Convert.ToDecimal(input_value);
                                truckController.SearchByPriceHigh(ref CurrentTrucksList, enter_price);
                                ChoosenOptionsList.Add("3");

                                Message.FillterAplyedSuccessfully();
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "4":
                        if (ChoosenOptionsList.Contains("4"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Enter price: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Price);
                            Regex num_regex_2 = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value) || num_regex_2.IsMatch(input_value))
                            {
                                decimal enter_price = Convert.ToDecimal(input_value);
                                truckController.SearchByPriceLow(ref CurrentTrucksList, enter_price);
                                ChoosenOptionsList.Add("4");

                                Message.FillterAplyedSuccessfully();
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "5":
                        if (ChoosenOptionsList.Contains("5"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Enter mileage: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value))
                            {
                                int enter_mileage = Convert.ToInt32(input_value);
                                truckController.SearchByMileageHigh(ref CurrentTrucksList, enter_mileage);
                                ChoosenOptionsList.Add("5");

                                Message.FillterAplyedSuccessfully();
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "6":
                        if (ChoosenOptionsList.Contains("6"))
                        {
                            Errors.RepeatedFilter();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Enter mileage: ");

                            // Check if input string only contain numeric charecters
                            string? input_value = Console.ReadLine();
                            Regex num_regex = new Regex(AutoIncrement.Numeric);
                            if (num_regex.IsMatch(input_value))
                            {
                                int enter_mileage = Convert.ToInt32(input_value);
                                truckController.SearchByMileageLow(ref CurrentTrucksList, enter_mileage);
                                ChoosenOptionsList.Add("6");

                                Message.FillterAplyedSuccessfully();
                            }
                            else
                            {
                                Errors.NonexistentOptionError();
                            };
                        }
                        break;
                    case "7":
                        Console.Clear();
                        TruckController.ShowAll(CurrentTrucksList);
                        return true;
                    case "8":
                        return false;
                    default:
                        Errors.NonexistentOptionError();
                        break;
                }

            }
        }

        public void Truck_AddToFavorite(User currentUser)
        {
            bool isContinue = true;
            Console.WriteLine("Enter wanted ID of truck to add to favorites or 0 to quit:");

            while (isContinue)
            {
                string? entered_value = Console.ReadLine();

                Regex num_regex = new Regex(AutoIncrement.Numeric);
                if (!num_regex.IsMatch(entered_value))
                {
                    Errors.MistakeError();
                    return;
                }

                int enterID = Convert.ToInt32(entered_value);
                if (enterID.Equals(0))
                {
                    return;
                }

                if (enterID < 0)
                {
                    Message.MistakeError();
                }

                IVehicle findedTruck = new Truck();
                if (truckController.GetVehicleByID(enterID, ref findedTruck))
                {
                    currentUser.AddFavorite(findedTruck);
                    Message.VehicleAddedToFav(enterID);
                }
                else
                {
                    Message.MistakeError();
                }

            }
        }

    }
}

