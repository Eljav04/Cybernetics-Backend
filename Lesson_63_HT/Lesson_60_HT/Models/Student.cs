using System;
namespace Lesson_60_HT.Models
{
	public class Student
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public int SubjectID { get; set; }
        public Subject StudentSubject { get; set; }

    }
}

