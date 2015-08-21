using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Homework31.WebApp.Models
{
    public class IRRContext
    {
        public const string CONNECTION_STRING_NAME = "irr";
        public const string DATABASE_NAME = "irr";
        public const string IRRDEFINITIONS_COLLECTION_NAME = "irrdefinitions";
        public const string FLOWS_COLLECTION_NAME = "flows";




        // This is ok... Normally, these or the entire IRRContext
        // would be put into an IoC container. We aren't using one,
        // so we'll just keep them statically here as they are 
        // thread-safe.
        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static IRRContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(DATABASE_NAME);
        }

        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoCollection<Student> Students
        {
            get { return _database.GetCollection<Student>(IRRDEFINITIONS_COLLECTION_NAME); }
        }
       
        
      

    }
}