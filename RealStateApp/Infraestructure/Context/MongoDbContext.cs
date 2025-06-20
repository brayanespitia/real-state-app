using MongoDB.Driver;
using RealStateApp.Domain.Entities;

namespace RealStateApp.Infraestructure.Context
{
    public class MongoDbContext
    {
        internal readonly object Database;
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDb:ConnectionString"]);
            _database = client.GetDatabase(configuration["MongoDb:DatabaseName"]);
        }

        public IMongoCollection<Property> Properties => _database.GetCollection<Property>("Properties");
        public IMongoCollection<Owner> Owners => _database.GetCollection<Owner>("Owners");
        public IMongoCollection<PropertyImage> PropertyImages => _database.GetCollection<PropertyImage>("PropertyImages");
    }
}
