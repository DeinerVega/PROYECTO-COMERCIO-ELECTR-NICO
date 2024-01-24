using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_COMMERCE.Models
{
    public class Record
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string BusinessName { get; set; }

        public string Adress { get; set; }
    

    }
}
