using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using Stock.Core.Repository;
using Stock.Infrastructure.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Infrastructure.Repository
{
    public class MongoDbContext
    {
        public readonly IMongoDatabase _database;
        public MongoDbContext(string ConnectionString, string DatabaseName)
        {
            MongoClientSettings settings = MongoClientSettings.FromConnectionString(ConnectionString);
            MongoClient mongoClient = new MongoClient(settings);
            _database = mongoClient.GetDatabase(DatabaseName);
        }
    }
}
