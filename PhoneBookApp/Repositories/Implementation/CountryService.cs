using System;
using PhoneBookApp.Models;
using PhoneBookApp.Repositories.Interfaces;

namespace PhoneBookApp.Repositories.Implementation
{
    //Country service class is inheriting from it's interface(ICountryService).
	public class CountryService : ICountryService
	{
        private readonly DatabaseContext context;
        
		public CountryService(DatabaseContext context)
		{
            this.context = context;
		}

        public bool Add(Country model)
        {
            try
            {
                context.Country.Add(model);
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
                context.Country.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Country FindById(int id)
        {
            return context.Country.Find(id);
        }

        public IEnumerable<Country> GetAll()
        {
            return context.Country.ToList();
        }

        public bool Update(Country model)
        {
            try
            {
                context.Country.Update(model);
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

