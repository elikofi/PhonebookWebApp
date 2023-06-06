using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PhoneBookApp.Models
{
	public class Contact
	{
		[Key] //Primary key for the Contact model.
		public int Id { get; set; }
        //all other fields are required because we want the user to enter these fields.
		[Required]
		public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public DateOnly BirthDay { get; set; }
        [Required]
        public string? About { get; set; }
        [Required]
        public int CountryId { get; set; }  

        [ValidateNever]
        [DisplayName("Upload picture")]
        public string ImageUrl { get; set; }

        [NotMapped]
        public string? CountryName { get; set; }

        [NotMapped]
        public List<SelectListItem>? CountryList { get; set; }

        
    }
}

