using System;
using System.Collections;
using System.Collections.Generic;
using AdditionalTools.Messages;
using System.Text.RegularExpressions;
using AdditionalTools.AutoIncremnet;


namespace VehicleSpace
{
    public class Truck : IVehicle
    {
        //Trucks properties
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }

        // 2 kind of construtor
        public Truck(string Brand,
        string Model,
        decimal Price,
        int Mileage)
        {
            ID = AutoIncrement.GetVehicleId();
            this.Brand = Brand;
            this.Model = Model;
            this.Price = Price;
            this.Mileage = Mileage;
        }

        public Truck() { }

        // Trucks brand and models
        public static readonly List<string> truckBrands = new()
        {
           "Ford", "Chevrolet", "Ram", "Toyota", "Nissan", "GMC", "Honda"
        };

        // Initialize the Hashtable with truck brands and their models
        public static readonly Hashtable truckModels = new()
        {
            ["Ford"] = new ArrayList { "F-150", "Super Duty", "Ranger", "Maverick", "F-250" },
            ["Chevrolet"] = new ArrayList { "Silverado 1500", "Silverado 2500HD", "Colorado", "Silverado 3500HD", "Tahoe" },
            ["Ram"] = new ArrayList { "1500", "2500", "3500", "Power Wagon", "Rebel" },
            ["Toyota"] = new ArrayList { "Tundra", "Tacoma", "Sequoia", "Hilux", "Land Cruiser" },
            ["Nissan"] = new ArrayList { "Titan", "Frontier", "NV3500", "Xterra", "Armada" },
            ["GMC"] = new ArrayList { "Sierra 1500", "Canyon", "Sierra 2500HD", "Yukon", "Sierra 3500HD" },
            ["Honda"] = new ArrayList { "Ridgeline", "Passport", "Pilot", "Odyssey", "CR-V" }
        };

        //Patterns for Brand / Model / Price / Quantity
        public readonly static Dictionary<string, Regex> CheckPatterns = new(){
            {"Brand", new Regex(@"^[a-zA-Z]+$") },
            {"Model", new Regex(@"^[a-zA-Z]+$") },
            {"Price", new Regex(@"^[0-9]+[.,][0-9]+$") },
            {"Mileage", new Regex(@"^[0-9]+$") }
        };

        // Main functionality

        // ShowInfo function
        public void ShowInfo()
        {
            Console.WriteLine(
            $"ID: {ID} \n" +
            $"Brand: {Brand} \n" +
            $"Model: {Model} \n" +
            $"Price: {Price} \n" +
            $"Mileage: {Mileage} \n" +
            "=========================");
        }

        // ShowBrands function
        public static void ShowBrands()
        {
            for (int i = 0; i < truckBrands.Count; i++)
            {
                Console.WriteLine($"{i}.{truckBrands[i]}");
            }
        }

        // ShowModels function
        public static void ShowModels(string brand)
        {
            ArrayList current_models = (ArrayList)truckModels[brand];

            for (int i = 0; i < current_models.Count; i++)
            {
                Console.WriteLine($"{i}.{current_models[i]}");
            }
        }

        //Filters functions
        public bool Filter_Brand(string brand)
        {
            if (Brand.Equals(brand))
            {
                return true;
            }
            return false;
        }

        public bool Filter_Model(string model)
        {
            if (Model.Equals(model))
            {
                return true;
            }
            return false;
        }

        public bool Filter_PriceHigher(decimal price)
        {
            if (Price >= price)
            {
                return true;
            }
            return false;
        }

        public bool Filter_PriceLower(decimal price)
        {
            if (Price <= price)
            {
                return true;
            }
            return false;
        }

        public bool Filter_MileageHigher(decimal mileage)
        {
            if (Mileage >= mileage)
            {
                return true;
            }
            return false;
        }

        public bool Filter_MileageLower(decimal mileage)
        {
            if (Mileage <= mileage)
            {
                return true;
            }
            return false;
        }

        public bool Update_Brand(string new_brand)
        {
            if (CheckPatterns["Brand"].IsMatch(new_brand))
            {
                Brand = new_brand;
                return true;
            }
            return false;
        }

        public bool Update_Model(string new_model)
        {
            if (CheckPatterns["Model"].IsMatch(new_model))
            {
                Model = new_model;
                return true;
            }
            return false;
        }

        public bool Update_Price(string new_price)
        {
            if (CheckPatterns["Price"].IsMatch(new_price) ||
                CheckPatterns["Mileage"].IsMatch(new_price))
            {
                Price = Convert.ToDecimal(new_price);
                return true;
            }
            return false;
        }

        public bool Update_Mileage(string new_mileage)
        {
            if (CheckPatterns["Mileage"].IsMatch(new_mileage))
            {
                Mileage = Convert.ToInt32(new_mileage);
                return true;
            }
            return false;
        }

        public void Update(string choosen_prop, string new_prop)
        {
            bool isChangable = false;
            switch (choosen_prop)
            {
                case "1":
                    if (Update_Brand(new_prop))
                    {
                        isChangable = true;
                    }
                    break;
                case "2":
                    if (Update_Model(new_prop))
                    {
                        isChangable = true;
                    }
                    break;
                case "3":
                    if (Update_Price(new_prop))
                    {
                        isChangable = true;
                    }
                    break;
                case "4":
                    if (Update_Mileage(new_prop))
                    {
                        isChangable = true;
                    }
                    break;
                default:
                    Errors.NonexistentOptionError();
                    return;
            }

            // Check if input new_prop is written in properer way
            if (isChangable)
            {
                Message.VehicleUpdated();
            }
            else
            {
                Errors.MistakeError();
            };
        }
    }
}

