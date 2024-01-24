using E_COMMERCE.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_COMMERCE.Repositories
{
    public class RecordCollection : IRecordCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Record> Collection;

        public RecordCollection()
        {
            Collection = _repository.db.GetCollection<Record>("Records");
        }

        public async Task DeleteRecord(string id)
        {
            var filter = Builders<Record>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Record>> GetAllRecords()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Record> GetRecordById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.
                FirstAsync();
        }

        public async Task InsertRecord(Record record)
        {
            await Collection.InsertOneAsync(record);
        }

        public async Task UpdateRecord(Record record)
        {
            var filter = Builders<Record>
                .Filter
                .Eq(s => s.Id, record.Id);

            await Collection.ReplaceOneAsync(filter, record);
        }
    }

}