using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcService.Converters;
using static GrpcService.Countries;

namespace GrpcService.Services
{
    public class CountriesService : CountriesBase
    {
        private readonly Repositories.MongoDB.Interfaces.ICountryRepository _countryRepositoryMongoDb;
        private readonly Repositories.MSSQL.Interfaces.ICountryRepository _countryRepositoryMSSQL;
        public CountriesService(Repositories.MongoDB.Interfaces.ICountryRepository countryRepositoryMongoDb,
            Repositories.MSSQL.Interfaces.ICountryRepository countryRepositoryMSSQL)
        {
            _countryRepositoryMongoDb = countryRepositoryMongoDb;
            _countryRepositoryMSSQL = countryRepositoryMSSQL;
        }

        /// <summary>
        /// Метод получения данных стран из MSSQL
        /// </summary>
        /// <returns>Список Моделей данных стран</returns>
        public override async Task<CountriesReply> GetCountriesAllMsSql(Empty empty, 
            ServerCallContext context)
        {
            IEnumerable<Dictionary.Models.MSSQL.Country> countries = await _countryRepositoryMSSQL.GetAsync();
            CountriesReply countriesReply = new();
            countriesReply.Countries
                .AddRange(countries.Select(country => country.ToProtobufCountryMsSql()));
            return countriesReply;
        }

        /// <summary>
        /// Метод получения данных стран из MongoDB
        /// </summary>
        /// <returns>Список моделей данных стран</returns>
        public override async Task<CountriesReply> GetCountriesAllMongoDb(Empty empty,
            ServerCallContext context)
        {
            IEnumerable<Dictionary.Models.MongoDB.Country> countries = 
                await _countryRepositoryMongoDb.GetAsync();
            CountriesReply countriesReply = new();
            countriesReply.Countries
                .AddRange(countries.Select(country => country.ToProtobufCountryMongoDb()));
            return countriesReply;
        }

        /// <summary>
        /// Метод получения данных стран из MSSQL с использованием пагинации.
        /// </summary>
        /// <param name="request">Модель данных для пагинации.</param>
        /// <returns>Список моделей данных стран.</returns>
        public override async Task<CountriesReply> GetCountriesMsSql(PaginationRequest request,
            ServerCallContext context)
        {
            IEnumerable<Dictionary.Models.MSSQL.Country> countries = 
                await _countryRepositoryMSSQL.GetAsync(request.Skip, request.Take);
            CountriesReply countriesReply = new();
            countriesReply.Countries
                .AddRange(countries.Select(country => country.ToProtobufCountryMsSql()));
            return countriesReply;
        }


        /// <summary>
        /// Метод получения данных стран из MongoDB с использованием пагинации.
        /// </summary>
        /// <param name="request">Модель данных для пагинации.</param>
        /// <returns>Список моделей данных стран.</returns>
        public override async Task<CountriesReply> GetCountriesMongoDb(PaginationRequest request,
            ServerCallContext context)
        {
            IEnumerable<Dictionary.Models.MongoDB.Country> countries =
                await _countryRepositoryMongoDb.GetAsync(request.Skip, request.Take);
            CountriesReply countriesReply = new();
            countriesReply.Countries
                .AddRange(countries.Select(country => country.ToProtobufCountryMongoDb()));
            return countriesReply;
        }
    }
}
