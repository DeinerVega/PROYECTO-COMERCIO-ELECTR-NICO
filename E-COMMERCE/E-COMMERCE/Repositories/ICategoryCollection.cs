using E_COMMERCE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_COMMERCE.Repositories
{
    public interface ICategoryCollection
    {
        
            Task InsertCategory(Category Category);

            Task UpdateCategory(Category Category);

            Task DeleteCategory(string id);

            Task<List<Category>> GetAllCategorys();
            Task<Category> GetCategoryById(string id);
    }
}
