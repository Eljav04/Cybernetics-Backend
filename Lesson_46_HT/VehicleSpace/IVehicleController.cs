using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace VehicleSpace
{
	internal interface IVehicleController
	{
		List<IVehicle> VehiclesData{ get; set; }
        

		void ShowAll();

        // Filter functions
        public void SearchByModel(ref List <IVehicle> vehicle_list, string model);
        public void SearchByBrand(ref List <IVehicle> vehicle_list, string brand);

        public void SearchByPriceHigh(ref List <IVehicle> vehicle_list, decimal price);
        public void SearchByPriceLow(ref List <IVehicle> vehicle_list, decimal price);

        public void SearchByMileageHigh(ref List <IVehicle> vehicle_list, int mileage);
        public void SearchByMileageLow(ref List <IVehicle> vehicle_list, int mileage);

        // Create and adding functions

        public bool CreateVehicle(ref IVehicle vehicle);
        public void AddVehicle(IVehicle new_vehicle);

        public void UpdateByID(int vehicleID);

        public bool IfExistID(int vehicleID);
    }
}

