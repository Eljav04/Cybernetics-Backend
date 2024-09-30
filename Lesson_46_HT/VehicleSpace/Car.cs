using System;
using System.Collections;
using System.Collections.Generic;
using AdditionalTools.Messages;
using System.Text.RegularExpressions;
using AdditionalTools.AutoIncremnet;


namespace VehicleSpace
{
    public class Car : IVehicle
    {
        //Cars properties
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }

        // 2 kind of construtor
        public Car(string Brand,
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

        public Car() { }

        // Cars brand and models
        public static readonly List<string> carBrands = new()
        {
            "Toyota", "Mercedes", "BMW", "Hundai", "Kia", "Audi", "Porsche"
        };

        // Initialize the Hashtable with car brands and their models
        public static readonly Hashtable carModels = new()
        {
            ["Toyota"] = new ArrayList { "Corolla", "Camry", "Prius", "RAV4", "Highlander" },
            ["Mercedes"] = new ArrayList { "C-Class", "E-Class", "S-Class", "GLA", "GLE" },
            ["BMW"] = new ArrayList { "3 Series", "5 Series", "X5", "X3", "7 Series" },
            ["Hundai"] = new ArrayList { "Elantra", "Sonata", "Tucson", "Santa Fe", "Kona" },
            ["Kia"] = new ArrayList { "Soul", "Sorento", "Sportage", "Telluride", "Rio" },
            ["Audi"] = new ArrayList { "A3", "A4", "A6", "Q5", "Q7" },
            ["Porsche"] = new ArrayList { "911", "Cayenne", "Panamera", "Macan", "Taycan" }
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
            for (int i = 0; i < carBrands.Count; i++)
            {
                Console.WriteLine($"{i}.{carBrands[i]}");
            }
        }

        // ShowModels function
        public static void ShowModels(string brand)
        {
            ArrayList current_models = (ArrayList)carModels[brand];

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

