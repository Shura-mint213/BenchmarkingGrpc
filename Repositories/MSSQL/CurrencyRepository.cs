using Dictionary.Models.MSSQL;
using Microsoft.Extensions.Options;
using Repositories.MSSQL.Interfaces;
using Dictionary.MSSQLContext;
using Microsoft.EntityFrameworkCore;

namespace Repositories.MSSQL
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly DictionaryContext _context;
        public CurrencyRepository(DictionaryContext dictionary)
        {
            _context = new DictionaryContext();
        }

        /// <inheritdoc/>        
        public async Task<IEnumerable<Currency>> GetAsync()
        {
            return await _context.Currencies.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Currency>> GetAsync(int skip, int take)
        {
            return await _context.Currencies
                .Skip(skip).Take(take).ToListAsync();
        }
    }
}
