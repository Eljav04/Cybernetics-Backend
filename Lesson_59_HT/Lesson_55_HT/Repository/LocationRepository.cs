using System;
using Lesson_55_HT.DAL;
namespace Lesson_55_HT.Repository
{
	public class LocationRepository
	{
        public List<Location> LocationList { get; set; }

		public LocationRepository()
		{
			using var DbContex = new AppDbContext();
			LocationList = DbContex.Locations.ToList();

        }

        public Location? GetByID(int? id)
			=> LocationList.FirstOrDefault(c => c.LocationId == id);
    }
}

