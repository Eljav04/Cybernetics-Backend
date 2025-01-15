using System;
using Lesson_55_HT.DAL;

namespace Lesson_55_HT.Repository
{
	public class PhoneNumRepository
	{
        public List<PhoneNumber> PhoneList { get; set; }
        public PhoneNumRepository()
		{
            using var DbContex = new AppDbContext();
            PhoneList = DbContex.PhoneNumbers.ToList();
        }

        public List<PhoneNumber>? GetByID(int? id)
            => PhoneList.Where(c => c.ContactId == id).ToList();
    }
}

