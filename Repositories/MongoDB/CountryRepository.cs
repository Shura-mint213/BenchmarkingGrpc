using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Dictionary.Models.MongoDB;
using Repositories.MongoDB.Interfaces;
using Shared.Models;
using Dictionary.MongoDBContext;

namespace Repositories.MongoDB
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DictionaryContext _context;
        public CountryRepository(IOptions<MongoSettings> settings) 
        {
            _context = new DictionaryContext(settings);
        }

        public async Task<IEnumerable<Country>> GetAsync()
        {
            return await _context.Countries.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Country>> GetAsync(int skip, int take)
        {
            return await _context.Countries.Find(_ => true)
                .Skip(skip).Limit(take).ToListAsync();
        }
    }
}
