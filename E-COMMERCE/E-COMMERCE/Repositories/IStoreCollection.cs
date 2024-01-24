using E_COMMERCE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_COMMERCE.Repositories
{
    public interface IStoreCollection
    {
        Task InsertStore(Store store);

        Task UpdateStore(Store store);

        Task DeleteStore(string id);

        Task<List<Store>> GetAllStores();
        Task<Store> GetStoreById(string id);
    }
}
