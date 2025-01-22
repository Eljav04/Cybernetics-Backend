using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson_60_HT.Models
{
	public class StudentDetails
	{
        [Key]
		public int Id { get; set; }
        public decimal Payment  { get; set; }
        public string Description { get; set; }

    }
}

