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

        /// <summary>
        /// Метод получения данных стран из MSSQL
        /// </summary>
        /// <returns>Список Моделей данных стран</returns>
        [HttpGet("GetCountriesAllMSSQL")]
        public async Task<IEnumerable<Dictionary.Models.MSSQL.Country>> GetCountriesAllMsSqlAsync()
        {
            return await _countryRepositoryMSSQL.GetAsync();
        }

        /// <summary>
        /// Метод получения данных стран из MongoDB
        /// </summary>
        /// <returns>Список моделей данных стран</returns>
        [HttpGet("GetCountriesAllMongoDB")]
        public async Task<IEnumerable<Dictionary.Models.MongoDB.Country>> GetCountriesAllMongoDbAsync()
        {
            return await _countryRepositoryMongoDb.GetAsync();
        }

        /// <summary>
        /// Метод получения данных стран из MSSQL с использованием пагинации.
        /// </summary>
        /// <param name="skip">Количество элементов, которые нужно пропустить.</param>
        /// <param name="take">Количество элементов, которые нужно взять.</param>
        /// <returns>Список моделей данных стран.</returns>
        [HttpGet("GetCountriesMSSQL/{skip:int}/{take:int}")]
        public async Task<IEnumerable<Dictionary.Models.MSSQL.Country>> GetCountriesMsSqlAsync(int skip,
            int take)
        {
            return await _countryRepositoryMSSQL.GetAsync(skip, take);
        }

        /// <summary>
        /// Метод получения данных стран из MongoDB с использованием пагинации.
        /// </summary>
        /// <param name="skip">Количество элементов, которые нужно пропустить.</param>
        /// <param name="take">Количество элементов, которые нужно взять.</param>
        /// <returns>Список моделей данных стран.</returns>
        [HttpGet("GetCountriesMongoDB{skip:int}/{take:int}")]
        public async Task<IEnumerable<Dictionary.Models.MongoDB.Country>> GetCountriesMongoDbAsync(int skip,
            int take)
        {
            return await _countryRepositoryMongoDb.GetAsync(skip, take);
        }
    }
}
