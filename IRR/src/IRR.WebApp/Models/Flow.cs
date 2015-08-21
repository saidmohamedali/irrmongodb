using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IRRCalulation.WebApp.Models
{
    public class Flow
    {
      
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string name { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Direction { get; set; }
        public String Allocation { get; set; }
        public Double Value { get; set; }

        
    }
}