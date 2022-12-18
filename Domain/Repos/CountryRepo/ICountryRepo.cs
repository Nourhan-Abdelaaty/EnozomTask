using Data.Models;
using Domain.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repos.CountryRepo
{
    public interface ICountryRepo : IGenericRepo<Country>
    {
    }
}
