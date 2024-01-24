using E_COMMERCE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_COMMERCE.Repositories
{
    public interface IRecordCollection
    {
        Task InsertRecord(Record record);

        Task UpdateRecord(Record record);

        Task DeleteRecord(string id);

        Task<List<Record>> GetAllRecords();
        Task<Record> GetRecordById(string id);
    }
}
