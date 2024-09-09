using Dictionary.Models.MongoDB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shared.Models;
using Shared.Statics;

namespace Dictionary.MongoDBContext
{
    public class DictionaryContext
    {
        private readonly IMongoDatabase _database = null;
        public DictionaryContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(DatabaseSettings.ConnectionStringMongoDB);
            if (client != null)
                _database = client.GetDatabase(DatabaseSettings.Database);
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
