using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Homework31.WebApp.Models
{
    public class User
    {
        // XXX WORK HERE
        // create an object suitable for insertion into the user collection
        // The homework instructions will tell you the schema that the documents 
        // must follow. Make sure to include Name and Email properties.

        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }

    public class News
    {
        // XXX WORK HERE
        // create an object suitable for insertion into the user collection
        // The homework instructions will tell you the schema that the documents 
        // must follow. Make sure to include Name and Email properties.

        public ObjectId Id { get; set; }
        public string topic { get; set; }
        public string author { get; set; }
        public List<string> tags { get; set; }

    }
}