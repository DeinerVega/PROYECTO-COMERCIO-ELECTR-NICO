using E_COMMERCE.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_COMMERCE.Repositories
{
    public class UserCollection : IUserCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<User> Collection;

        public UserCollection()
        {
            Collection = _repository.db.GetCollection<User>("Users");
        }

        public async Task DeleteUser(string id)
        {
            var filter = Builders<User>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.
                FirstAsync();
        }

        public async Task InsertUser(User user)
        {
            await Collection.InsertOneAsync(user);
        }

        public async Task UpdateUser(User user)
        {
            var filter = Builders<User>
                .Filter
                .Eq(s => s.Id, user.Id);

            await Collection.ReplaceOneAsync(filter, user);
        }
    }
}
