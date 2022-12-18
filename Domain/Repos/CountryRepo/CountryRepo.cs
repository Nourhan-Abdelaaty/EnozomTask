using Data.Models;
using Domain.Repos.GenericRepo;
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
    }
}
