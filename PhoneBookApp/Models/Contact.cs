using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PhoneBookApp.Models
{
	public class Contact
	{
		[Key] //Primary key for the Contact model.
		public int Id { get; set; }
        //all other fields are required because we don't want then to be nullable.
		[Required]
		public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public int Number { get; set; }
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
        public virtual Country? Country { get; set; }//

        [Required]//have to add views for this
        public DateTime StartingDate { get; set; }

        [NotMapped]
        [DisplayName("Upload picture")]
        public IFormFile ProfilePicture { get; set; }

        [NotMapped]
        public string? CountryName { get; set; }

        [NotMapped]
        public List<SelectListItem>? CountryList { get; set; }

        
    }
}

