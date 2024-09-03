using Microsoft.AspNetCore.Mvc;
using MongoModels;
using Repositories.Mongo.Interfaces;

namespace DataServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        public CountriesController(ICountryRepository countryRepository) 
        {
            _countryRepository = countryRepository;        
        }

        [Route("getCountries")]
        [HttpGet]
        public async Task<IEnumerable<Country>> Get()
        {
            return await _countryRepository.Get();
        }
    }
}
