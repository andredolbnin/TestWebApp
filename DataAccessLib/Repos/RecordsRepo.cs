using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DataAccessLib
{
    public class RecordsRepo
    {
        public const string CollectionName = "Records";

        readonly IMongoCollection<Record> _collection;

        public RecordsRepo(IMongoDatabase database)
        {
            _collection = database.GetCollection<Record>(CollectionName);
            _collection.Indexes.CreateOne(new CreateIndexModel<Record>(Builders<Record>.IndexKeys.Ascending(q => q.CreateDateTime)));
        }

        public async Task<List<Record>> List()
        {
            return await _collection.Find(Builders<Record>.Filter.Empty).SortBy(q => q.CreateDateTime).ToListAsync();
        }

        public async Task AddRecord(Record record)
        {
            await _collection.InsertOneAsync(record);
        }
    }
}