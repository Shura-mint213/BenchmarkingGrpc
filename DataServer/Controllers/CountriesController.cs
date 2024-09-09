using Microsoft.AspNetCore.Mvc;
using Dictionary.Models.MongoDB;
using Dictionary.Models.MSSQL;
using Repositories.MongoDB.Interfaces;
using Repositories.MSSQL.Interfaces;


namespace DataServer.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly Repositories.MongoDB.Interfaces.ICountryRepository _countryRepositoryMongoDb;
        private readonly Repositories.MSSQL.Interfaces.ICountryRepository _countryRepositoryMSSQL;
        public CountriesController(Repositories.MongoDB.Interfaces.ICountryRepository countryRepositoryMongoDb,
            Repositories.MSSQL.Interfaces.ICountryRepository countryRepositoryMSSQL) 
        {
            _countryRepositoryMongoDb = countryRepositoryMongoDb;
            _countryRepositoryMSSQL = countryRepositoryMSSQL;
        }

        //[Route("GetCountriesAllMSSQL")]
        [HttpGet("GetCountriesAllMSSQL")]
        public async Task<IEnumerable<Dictionary.Models.MSSQL.Country>> GetCountriesAllMsSqlAsync()
        {
            return await _countryRepositoryMSSQL.GetAsync();
        }

        //[Route("GetCountriesAllMongoDB")]
        [HttpGet("GetCountriesAllMongoDB")]
        public async Task<IEnumerable<Dictionary.Models.MongoDB.Country>> GetCountriesAllMongoDbAsync()
        {
            return await _countryRepositoryMongoDb.GetAsync();
        }

        //[Route("GetCountriesMSSQL/{skip:int}/{take:int}")]
        [HttpGet("GetCountriesMSSQL/{skip:int}/{take:int}")]
        public async Task<IEnumerable<Dictionary.Models.MSSQL.Country>> GetCountriesMsSqlAsync(int skip,
            int take)
        {
            return await _countryRepositoryMSSQL.GetAsync(skip, take);
        }

        //[Route("GetCountriesMongoDB{skip:int}/{take:int}")]
        [HttpGet("GetCountriesMongoDB{skip:int}/{take:int}")]
        public async Task<IEnumerable<Dictionary.Models.MongoDB.Country>> GetCountriesMongoDbAsync(int skip,
            int take)
        {
            return await _countryRepositoryMongoDb.GetAsync(skip, take);
        }
    }
}
