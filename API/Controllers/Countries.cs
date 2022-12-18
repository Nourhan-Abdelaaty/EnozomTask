using Data.Models;
using Domain.Repos.CountryRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Countries : ControllerBase
    {

        private readonly ICountryRepo CountryDB;
        public Countries(ICountryRepo _CountryDB)
        {
            CountryDB = _CountryDB;
        }


        [HttpGet]
        [Route("GetAllCountries")]
        public IActionResult getall()
        {
            return Ok(CountryDB.GetAllWithPopulation());
        }
       
        [HttpGet]
        [Route("GetByID")]
        public IActionResult GetCountryByID(int id)
        {
            return Ok(CountryDB.GetCoutryByID(id));
        }
        [HttpPost]  
        public IActionResult AddOrUpdate(List<Country> c)
        {
            return Ok(CountryDB.GetOrEdit(c));
        }
    }
}
