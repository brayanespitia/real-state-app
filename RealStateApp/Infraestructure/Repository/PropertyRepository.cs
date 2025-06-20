using MongoDB.Driver;
using RealStateApp.Domain.Entities;
using RealStateApp.Domain.Repository;
using RealStateApp.Infraestructure.Context;

namespace RealStateApp.Infraestructure.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly MongoDbContext mongoDbContext;

        public PropertyRepository(MongoDbContext dbContext)
        {
            mongoDbContext = dbContext;
        }
        public async Task AddAsync(Property property)
        {
             await mongoDbContext.Properties.InsertOneAsync(property);
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Property>> GetAllAsync()
        {
            return await mongoDbContext.Properties
                .Find(_ => true)
            .ToListAsync();
        }

        public async Task<Property> GetByIdAsync(string id)
        {
            return await mongoDbContext.Properties
                .Find(p => p.IdProperty == id)
                .FirstOrDefaultAsync();
        }

        public Task UpdateAsync(Property property)
        {
            throw new NotImplementedException();
        }

    }
}
