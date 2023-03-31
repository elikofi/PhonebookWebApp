using System;
using System.Reflection;
using PhoneBookApp.Models;

namespace PhoneBookApp.Repositories.Interfaces
{
	public interface ICountryService
	{
		//Declaration of methods is done here in the interface.

		bool Add(Country model);

		bool Update(Country model);

		bool Delete(int id);

		Country FindById(int id);

		IEnumerable<Country> GetAll();
	}
}

