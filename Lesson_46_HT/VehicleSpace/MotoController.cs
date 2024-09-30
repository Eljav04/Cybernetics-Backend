using System;
using AdditionalTools.Messages;
using System.Collections;
using System.Text.RegularExpressions;
using AdditionalTools.AutoIncremnet;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VehicleSpace
{
    public class MotoController : IVehicleController
    {
        // List that contain all Motos 
        public List<IVehicle> VehiclesData { get; set; }
        public MotoController()
        {
            VehiclesData = new();
        }

        internal readonly List<string> Properties = new()
        {
            "Brand", "Model", "Price", "Mileage"
        };

        // Main functionality
        // ShowAll function
        public void ShowAll()
        {
            foreach (IVehicle vehicle in VehiclesData)
            {
                vehicle.ShowInfo();
            }
        }

        // Show only by require list
        public static void ShowAll(List<IVehicle> requiredList)
        {
            foreach (IVehicle vehicle in requiredList)
            {
                vehicle.ShowInfo();
            }
        }

        public bool GetVehicleByID(int vehicleID, ref IVehicle findedVehicle)
        {
            foreach (IVehicle vehicle in VehiclesData)
            {
                if (vehicle.ID == vehicleID)
                {
                    findedVehicle = vehicle;
                    return true;
                }
            }
            return false;
        }

        // SearchBySmth functions
        public void SearchByModel(ref List<IVehicle> vehicle_list, string model)
        {
            foreach (IVehicle vehicle in VehiclesData)
            {
                if (!vehicle.Filter_Model(model))
                {
                    vehicle_list.Remove(vehicle);
                }
            }
        }

        public void SearchByBrand(ref List<IVehicle> vehicle_list, string brand)
        {
            foreach (IVehicle vehicle in VehiclesData)
            {
                if (!vehicle.Filter_Brand(brand))
                {
                    vehicle_list.Remove(vehicle);
                }
            }
        }

        public void SearchByPriceHigh(ref List<IVehicle> vehicle_list, decimal price)
        {
            foreach (IVehicle vehicle in VehiclesData)
            {
                if (!vehicle.Filter_PriceHigher(price))
                {
                    vehicle_list.Remove(vehicle);
                }
            }
        }

        public void SearchByPriceLow(ref List<IVehicle> vehicle_list, decimal price)
        {
            foreach (IVehicle vehicle in VehiclesData)
            {
                if (!vehicle.Filter_PriceLower(price))
                {
                    vehicle_list.Remove(vehicle);
                }
            }
        }

        public void SearchByMileageHigh(ref List<IVehicle> vehicle_list, int mileage)
        {
            foreach (IVehicle vehicle in VehiclesData)
            {
                if (!vehicle.Filter_MileageHigher(mileage))
                {
                    vehicle_list.Remove(vehicle);
                }
            }
        }

        public void SearchByMileageLow(ref List<IVehicle> vehicle_list, int mileage)
        {
            foreach (IVehicle vehicle in VehiclesData)
            {
                if (!vehicle.Filter_MileageLower(mileage))
                {
                    vehicle_list.Remove(vehicle);
                }
            }
        }

        private bool ChooseBrand(ref string choosenBrand)
        {
            Console.Clear();
            Moto.ShowBrands();
            Console.WriteLine("Choose brand:");

            string? brand_id = Console.ReadLine();
            Regex num_regex = new Regex(AutoIncrement.Numeric);

            if (!num_regex.IsMatch(brand_id))
            {
                return false;
            }

            int int_brand_id = Convert.ToInt32(brand_id);
            if (int_brand_id < 0 || int_brand_id >= Moto.motoBrands.Count)
            {
                return false;
            }

            choosenBrand = Moto.motoBrands[int_brand_id];
            return true;
        }

        private bool ChooseModel(ref string choosenModel, string choosenBrand)
        {
            Console.Clear();
            Moto.ShowModels(choosenBrand);
            Console.WriteLine("Choose models:");

            string? model_id = Console.ReadLine();
            Regex num_regex = new Regex(AutoIncrement.Numeric);
            if (!num_regex.IsMatch(model_id))
            {
                return false;
            }

            int int_model_id = Convert.ToInt32(model_id);

            ArrayList choosenModelList = (ArrayList)Moto.motoModels[choosenBrand];
            if (int_model_id < 0 || int_model_id >= choosenModelList.Count)
            {
                return false;
            }

            choosenModel = (string)choosenModelList[int_model_id];
            return true;

        }
        // Create functions
        public bool CreateVehicle(ref IVehicle vehicle)
        {
            // Brand choose
            string choosenBrand = "";
            if (!ChooseBrand(ref choosenBrand))
            {
                return false;
            }

            // Model choose
            string choosenModel = "";
            if (!ChooseModel(ref choosenModel, choosenBrand))
            {
                return false;
            }

            // Price input
            Console.Clear();
            Console.WriteLine("Enter price:");

            string? current_price = Console.ReadLine();
            if (!Moto.CheckPatterns["Price"].IsMatch(current_price))
            {
                if (!Moto.CheckPatterns["Mileage"].IsMatch(current_price))
                {
                    return false;
                }
            }

            // Mileage input
            Console.Clear();
            Console.WriteLine("Enter mileage:");

            string? current_mileage = Console.ReadLine();
            if (!Moto.CheckPatterns["Mileage"].IsMatch(current_mileage))
            {
                return false;
            }


            vehicle = new Moto(
                choosenBrand,
                choosenModel,
                Convert.ToDecimal(current_price),
                Convert.ToInt32(current_mileage)
                );
            return true;

        }

        // AddVehicle function
        public void AddVehicle(IVehicle new_Moto)
        {
            VehiclesData.Add(new_Moto);
        }

        // RemoveVehicle function
        public bool RemoveVehicle(int vehicleID)
        {
            foreach (IVehicle vehicle in VehiclesData)
            {
                if (vehicle.ID == vehicleID)
                {
                    VehiclesData.Remove(vehicle);
                    return true;
                }
            }
            return false;
        }

        public void UpdateByID(int vehicleID)
        {
            IVehicle currentVehicle = new Moto();
            GetVehicleByID(vehicleID, ref currentVehicle);

            Console.Clear();
            Console.WriteLine("What do you want to change?");
            for (int i = 0; i < Properties.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Update {Properties[i]}");
            }

            Console.Write("Choose option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    string choosenBrand = "";
                    if (!ChooseBrand(ref choosenBrand))
                    {
                        Errors.MistakeError();
                        return;
                    }
                    string choosenModel = "";
                    if (!ChooseModel(ref choosenModel, choosenBrand))
                    {
                        Errors.MistakeError();
                        return;
                    }
                    currentVehicle.Update("1", choosenBrand);
                    currentVehicle.Update("2", choosenModel);
                    break;
                case "2":
                    choosenModel = "";
                    choosenBrand = currentVehicle.Brand;
                    if (!ChooseModel(ref choosenModel, choosenBrand))
                    {
                        Errors.MistakeError();
                        return;
                    }
                    currentVehicle.Update("2", choosenModel);
                    break;
                case "3":
                    Console.Write($"Enter new property : ");
                    currentVehicle.Update("3", Console.ReadLine());
                    break;
                case "4":
                    Console.Write($"Enter new property : ");
                    currentVehicle.Update("4", Console.ReadLine());
                    break;
                default:
                    Errors.NonexistentOptionError();
                    return;
            }
        }

        public bool IfExistID(int vehicleID)
        {
            foreach (IVehicle vehicle in VehiclesData)
            {
                if (vehicle.ID == vehicleID)
                {
                    return true;
                }
            }
            return false;
        }



    }
}

