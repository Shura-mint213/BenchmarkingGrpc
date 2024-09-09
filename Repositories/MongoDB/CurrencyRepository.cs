using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Dictionary.Models.MongoDB;
using Repositories.MongoDB.Interfaces;
using Shared.Models;
using Dictionary.MongoDBContext;

namespace Repositories.MongoDB
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly DictionaryContext _context;
        public CurrencyRepository(IOptions<MongoSettings> settings)
        {
            _context = new DictionaryContext(settings);
        }

        public async Task<IEnumerable<Currency>> GetAsync()
        {
            return await _context.Currencies.Find(_ => true).ToListAsync();
        }


        public async Task<IEnumerable<Currency>> GetAsync(int skip, int take)
        {
            return await _context.Currencies.Find(_ => true)
                .Skip(skip).Limit(take).ToListAsync();
        }
    }
}
