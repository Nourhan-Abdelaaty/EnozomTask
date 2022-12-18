using Data.Models;
using Domain.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repos.CountryRepo
{
    public class CountryRepo : GenericRepo<Country>, ICountryRepo
    {
        private readonly DBContext context;
        public CountryRepo(DBContext _context) : base(_context)
        {
            context = _context;
        }

        public IEnumerable<Country> GetAllWithPopulation()
        {
            var c = context.Countries.Include(a => a.PopulationCounts);
            return (IEnumerable<Country>)c;

        }


        public IEnumerable<Country> GetByName(String name)
        {
            if(context.Countries.Where(a => a.CountryName == name)!=null)
            return context.Countries.Where(a => a.CountryName == name).Include(a => a.PopulationCounts);
            else
            return context.Countries.Where(a => a.CountryName == name);

        }

        public List<Country> GetOrEdit(List<Country> ls)
        {
            foreach (var i in ls)
            {
                if (GetByName(i.CountryName).Select(a=>a.CountryName) == null)
                {
                    context.Countries.Add(i); 
                }
                else
                {
                    context.Countries.Update(i);
                }
            }

            return ls;
        }

        public IEnumerable<Country> GetCoutryByID(int id)
        {
            var i = context.Countries.Where(a => a.CountryID == id).Include(a => a.PopulationCounts);
            return i;
        }

    }
}
