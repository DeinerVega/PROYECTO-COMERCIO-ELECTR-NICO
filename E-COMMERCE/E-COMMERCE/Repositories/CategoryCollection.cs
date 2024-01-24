using E_COMMERCE.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_COMMERCE.Repositories
{
    public class CategoryCollection : ICategoryCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Category> Collection;

        public CategoryCollection()
        {
            Collection = _repository.db.GetCollection<Category>("Categorys");
        }

        public async Task DeleteCategory(string id)
        {
            var filter = Builders<Category>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Category>> GetAllCategorys()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Category> GetCategoryById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.
                FirstAsync();
        }

        public async Task InsertCategory(Category category)
        {
            await Collection.InsertOneAsync(category);
        }

        public async Task UpdateCategory(Category category)
        {
            var filter = Builders<Category>
                .Filter
                .Eq(s => s.Id, category.Id);

            await Collection.ReplaceOneAsync(filter, category);
        }
    }
}
