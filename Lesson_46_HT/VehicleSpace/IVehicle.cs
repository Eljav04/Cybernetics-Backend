using System;
namespace VehicleSpace
{
	public interface IVehicle
	{
        int ID { get; set; }
        string  Brand { get; set; }
        string  Model { get; set; }
        decimal Price { get; set; }
        int Mileage { get; set; }

        void ShowInfo();

        //Filters functions
        bool Filter_Brand(string brand);
        bool Filter_Model(string model);
        bool Filter_PriceHigher(decimal price);
        bool Filter_PriceLower(decimal price);
        bool Filter_MileageHigher(decimal mileage);
        bool Filter_MileageLower(decimal mileage);

        // Updtade functions for every property separetly
        bool Update_Brand(string new_brand);
        bool Update_Model(string new_model);
        bool Update_Price(string new_model);
        bool Update_Mileage(string new_model);

        void Update(string choosen_prop, string new_prop);
    }
}

