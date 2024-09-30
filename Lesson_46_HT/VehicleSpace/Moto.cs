using System;
using System.Collections;
using System.Collections.Generic;
using AdditionalTools.Messages;
using System.Text.RegularExpressions;
using AdditionalTools.AutoIncremnet;


namespace VehicleSpace
{
    public class Moto : IVehicle
    {
        //Motocycles properties
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }

        // 2 kind of construtor
        public Moto(string Brand,
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

        public Moto() { }

        // Motos brand and models
        public static readonly List<string> motoBrands = new()
        {
            "Harley-Davidson", "Yamaha", "Kawasaki", "Honda", "Ducati", "BMW", "Suzuki"
        };

        // Initialize the Hashtable with Moto brands and their models
        public static readonly Hashtable motoModels = new()
        {
            ["Harley-Davidson"] = new ArrayList { "Street Glide", "Road King", "Iron 883", "Fat Boy", "Softail" },
            ["Yamaha"] = new ArrayList { "YZF-R1", "MT-07", "FZ-09", "VMAX", "Tracer 900" },
            ["Kawasaki"] = new ArrayList { "Ninja ZX-6R", "Versys 650", "Z1000", "KLR 650", "Vulcan S" },
            ["Honda"] = new ArrayList { "CBR1000RR", "CB500F", "CRF450R", "Africa Twin", "Shadow Phantom" },
            ["Ducati"] = new ArrayList { "Panigale V4", "Monster 1200", "Scrambler Icon", "Diavel 1260", "Multistrada V4" },
            ["BMW"] = new ArrayList { "S1000RR", "R1250GS", "K1600GTL", "F900R", "G310R" },
            ["Suzuki"] = new ArrayList { "GSX-R1000", "V-Strom 650", "SV650", "Hayabusa", "Boulevard M109R" }
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
            for (int i = 0; i < motoBrands.Count; i++)
            {
                Console.WriteLine($"{i}.{motoBrands[i]}");
            }
        }

        // ShowModels function
        public static void ShowModels(string brand)
        {
            ArrayList current_models = (ArrayList)motoModels[brand];

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

