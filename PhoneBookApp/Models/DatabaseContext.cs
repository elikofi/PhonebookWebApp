using System;
using Microsoft.EntityFrameworkCore;

namespace PhoneBookApp.Models
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options ) : base(options)
		{

		}

		//this is representing all the entities in the context that can be queried from the database.
		

		public DbSet<Country> Country { get; set; }

		public DbSet<Contact> Contact { get; set; }

		//public DbSet<Image> Images { get; set; }
	}
}

