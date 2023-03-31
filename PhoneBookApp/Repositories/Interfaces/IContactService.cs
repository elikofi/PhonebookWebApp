using System;
using System.Reflection;
using PhoneBookApp.Models;

namespace PhoneBookApp.Repositories.Interfaces
{
	public interface IContactService
	{
		bool Add(Contact model);

		bool Update(Contact model);

		bool Delete(int id);

		Contact FindById(int id);

		IEnumerable<Contact> GetAll();

		IEnumerable<Contact> GetBySearch();
	}
}

