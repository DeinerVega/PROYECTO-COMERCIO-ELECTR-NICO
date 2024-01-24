using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_COMMERCE.Models
{
    public class Store
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Record { get; set; }
        public string Product { get; set; }
        public string User { get; set; }
    }
}
