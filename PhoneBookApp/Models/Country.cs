using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Models
{
	public class Country
	{
		//the primary key for our country model
		[Key]
		public int Id { get; set; }

		//making this required because we don't want it to be nullable.
		[Required]
		public string? CountryName { get; set; }

		//public object? Picture { get; set; }
	}
}

