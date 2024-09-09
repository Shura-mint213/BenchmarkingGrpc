using Dictionary.Models.MSSQL;
using Dictionary.MSSQLContext;
using Microsoft.EntityFrameworkCore;
using Repositories.MSSQL.Interfaces;

namespace Repositories.MSSQL
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DictionaryContext _context;
        public CountryRepository(DictionaryContext context) 
        { 
            _context = context;
        }


        /// <inheritdoc/>        
        public async Task<IEnumerable<Country>> GetAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Country>> GetAsync(int skip, int take)
        {
            return await _context.Countries
                .Skip(skip).Take(take).ToListAsync();
        }
    }
}
