using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson_60_HT.Models
{
	public class Student
	{
        [Key]
		public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public int SubjectID { get; set; }
        public Subject StudentSubject { get; set; }

        public int StudentDetailsID { get; set; }
        public StudentDetails StudentDetails { get; set; }

    }
}

