using System;
using PhoneBookApp.Models;
using PhoneBookApp.Repositories.Interfaces;

namespace PhoneBookApp.Repositories.Implementation
{
	public class ContactService : IContactService
	{
        private readonly DatabaseContext context;

		public ContactService(DatabaseContext context)
		{
            this.context = context;
		}

        public bool Add(Contact model)
        {
            try
            {
                context.Contact.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var result = this.FindById(id);
                if (result == null)
                {
                    return false;
                }
                context.Contact.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Details(int id)
        {
            try
            {
                var result = this.FindById(id);
                if (result == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Contact FindById(int id)
        {
            return context.Contact.Find(id);
        }

        public IEnumerable<Contact> GetAll()
        {
            var result = (from contact in context.Contact
                          join country in context.Country on contact.CountryId equals country.Id
                          select new Contact
                          {
                              Id = contact.Id,
                              CountryId = contact.CountryId,
                              FirstName = contact.FirstName,
                              Number = contact.Number,
                              LastName = contact.LastName,
                              Email = contact.Email,
                              Address = contact.Address,
                              BirthDay = contact.BirthDay,
                              About = contact.About,
                              CountryName = country.CountryName
                          }).ToList();
            return result;
        }

        public IEnumerable<Contact> GetBySearch()
        {
            var result = (from contact in context.Contact
                          join country in context.Country on contact.CountryId equals country.Id
                          select new Contact
                          {
                              Id = contact.Id,
                              CountryId = contact.CountryId,
                              FirstName = contact.FirstName,
                              LastName = contact.LastName,
                              Number = contact.Number,
                              Email = contact.Email,
                              Address = contact.Address,
                              BirthDay = contact.BirthDay,
                              About = contact.About,
                              CountryName = country.CountryName
                          }).ToList();
            return result;
        }

        public bool Update(Contact model)
        {
            try
            {
                context.Contact.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

