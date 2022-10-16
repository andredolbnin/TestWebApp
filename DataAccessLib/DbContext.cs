using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace DataAccessLib
{
    public class DbContext
    {
        private readonly string _connectionString;
        private readonly string _dbName;

        public MongoServerAddress Server { get; }
        public string DbName => _dbName;

        public DbContext(string connectionString, string dbName)
        {
            _connectionString = connectionString;
            _dbName = dbName;

            var client = new MongoClient(_connectionString);
            Database = client.GetDatabase(_dbName);

            Server = client.Settings.Server;

            RecordsRepo = new RecordsRepo(Database);
        }

        public void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(this);
            serviceCollection.AddSingleton(Database);
            serviceCollection.AddSingleton(RecordsRepo);
        }

        public IMongoDatabase Database { get; }
        public RecordsRepo RecordsRepo { get; }
    }
}
