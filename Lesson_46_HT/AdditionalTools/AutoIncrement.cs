using System;
using System.Collections;

namespace AdditionalTools.AutoIncremnet
{
	public static class AutoIncrement
	{
        //Patterns
        public readonly static string Numeric = @"^[0-9]+$";
        public readonly static string Price = @"^[0-9]+[.,][0-9]+$";

        // Autoincremented IDs
        private static int user_id = 1;
		private static int vehicle_id = 1;

        public static int GetUserId() => user_id++;
        public static int GetVehicleId() => vehicle_id++;

    }
}

