using E_COMMERCE.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_COMMERCE.Repositories
{
    public class StoreCollection : IStoreCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Store> Collection;

        public StoreCollection()
        {
            Collection = _repository.db.GetCollection<Store>("Stores");
        }

        public async Task DeleteStore(string id)
        {
            var filter = Builders<Store>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Store>> GetAllStores()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Store> GetStoreById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.
                FirstAsync();
        }

        public async Task InsertStore(Store store)
        {
            await Collection.InsertOneAsync(store);
        }

        public async Task UpdateStore(Store store)
        {
            var filter = Builders<Store>
                .Filter
                .Eq(s => s.Id, store.Id);

            await Collection.ReplaceOneAsync(filter, store);
        }
    }

}
