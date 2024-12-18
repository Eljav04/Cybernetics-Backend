using System;
using System.ComponentModel.DataAnnotations;
namespace RegistrationForm.Models
{
	public class User
	{
		[Required(ErrorMessage = "Name field can not be empty")]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lastname field can not be empty")]
        [StringLength(30, MinimumLength = 2)]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email is not correct")]
		public string Email { get; set; }

        [Required]
        public bool Participate { get; set; }
	}
}

