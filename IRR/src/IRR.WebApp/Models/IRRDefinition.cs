using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IRRCalulation.WebApp.Models
{
    public class IRRDefinition
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public List<Allocation> Allocations { get; set; }
        public List<ObjectId> Ancestors { get; set; }

        public IRRDefinition()
        {
            Allocations = new List<Allocation>();
            Ancestors = new List<ObjectId>();
        }
    }
}