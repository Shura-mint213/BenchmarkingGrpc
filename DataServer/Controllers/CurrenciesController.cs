using Microsoft.AspNetCore.Mvc;

namespace DataServer.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class CurrenciesController : ControllerBase
    {
        private readonly Repositories.MongoDB.Interfaces.ICurrencyRepository _currencyRepositoryMongoDb;
        private readonly Repositories.MSSQL.Interfaces.ICurrencyRepository _currencyRepositoryMSSQL;
        public CurrenciesController(Repositories.MongoDB.Interfaces.ICurrencyRepository currencyRepositoryMongoDb,
            Repositories.MSSQL.Interfaces.ICurrencyRepository currencyRepositoryMSSQL)
        {
            _currencyRepositoryMongoDb = currencyRepositoryMongoDb;
            _currencyRepositoryMSSQL = currencyRepositoryMSSQL;
        }

        [Route("GetCurrenciesMSSQL")]
        [HttpGet]
        public async Task<IEnumerable<Dictionary.Models.MSSQL.Currency>> GetMsSqlAsync()
        {
            return await _currencyRepositoryMSSQL.GetAsync();
        }

        [Route("GetCurrenciesMongoDB")]
        [HttpGet]
        public async Task<IEnumerable<Dictionary.Models.MongoDB.Currency>> GetMongoDbAsync()
        {
            return await _currencyRepositoryMongoDb.GetAsync();
        }

        [Route("GetCurrenciesMSSQL/{skip:int}/{take:int}")]
        [HttpGet]
        public async Task<IEnumerable<Dictionary.Models.MSSQL.Currency>> GetMsSqlAsync(int skip,
            int take)
        {
            return await _currencyRepositoryMSSQL.GetAsync(skip, take);
        }

        [Route("GetCurrenciesMongoDB{skip:int}/{take:int}")]
        [HttpGet]
        public async Task<IEnumerable<Dictionary.Models.MongoDB.Currency>> GetMongoDbAsync(int skip,
            int take)
        {
            return await _currencyRepositoryMongoDb.GetAsync(skip, take);
        }
    }
}
