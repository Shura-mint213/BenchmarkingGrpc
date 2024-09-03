using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using MongoDB.Driver;
using MongoModels;
using Shared.Models;

namespace MongoContext
{
    public class DictionaryContext
    {
        private readonly IMongoDatabase _database = null;
        public DictionaryContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Currency> Currencies
        {
            get
            {
                return _database.GetCollection<Currency>(nameof(Currencies));
            }
        }

        public IMongoCollection<Country> Countries
        {
            get
            {
                return _database.GetCollection<Country>(nameof(Countries));
            }
        }
    }
}
