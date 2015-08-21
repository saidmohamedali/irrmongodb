using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace IRRCalulation.WebApp.Models
{
    public class IRRContext
    {
        public const string CONNECTION_STRING_NAME = "IRR";
        public const string DATABASE_NAME = "irr";
        public const string IRRDEFINITIONS_COLLECTION_NAME = "irrdefinitions";
        public const string FLOWS_COLLECTION_NAME = "flows";

        // This is ok... Normally, they would be put into
        // an IoC container.
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

        public IMongoCollection<IRRDefinition> IRRDefinitions
        {
            get { return _database.GetCollection<IRRDefinition>(IRRDEFINITIONS_COLLECTION_NAME); }
        }

        public IMongoCollection<Flow> Flows
        {
            get { return _database.GetCollection<Flow>(FLOWS_COLLECTION_NAME); }
        }
    }
}