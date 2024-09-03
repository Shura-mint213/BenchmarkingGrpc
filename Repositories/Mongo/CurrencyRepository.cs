using Microsoft.Extensions.Options;
using MongoContext;
using MongoDB.Driver;
using MongoModels;
using Repositories.Mongo.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Mongo
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly DictionaryContext _dictionary;
        public CurrencyRepository(IOptions<MongoSettings> settings)
        {
            _dictionary = new DictionaryContext(settings);
        }

        public async Task<IEnumerable<Currency>> Get()
        {
            return await _dictionary.Currencies.Find(_ => true).ToListAsync();
        }
    }
}
