using MongoDB.Bson;
using MongoDB.Driver;
using RealStateApp.Domain.Entities;
using RealStateApp.Domain.Repository;
using RealStateApp.Infraestructure.Context;

namespace RealStateApp.Infraestructure.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly MongoDbContext mongoDbContext;

        public OwnerRepository(MongoDbContext dbContext)
        {
            mongoDbContext = dbContext;
        }

        public async Task<List<Owner>> GetAllAsync()
        {
            return await mongoDbContext.Owners
                .Find(_ => true)
            .ToListAsync();

        }
        public async Task AddAsync(Owner owner)
        {
            
            await  mongoDbContext.Owners
                .InsertOneAsync(owner);
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

       

        public async Task<Owner> GetByIdAsync(string id)
        {
            return await mongoDbContext.Owners
                .Find(p => p.IdOwner == id)
                .FirstOrDefaultAsync();
        }

        public Task UpdateAsync(Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}
