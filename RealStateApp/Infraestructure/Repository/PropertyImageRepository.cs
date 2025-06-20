using MongoDB.Driver;
using RealStateApp.Domain.Entities;
using RealStateApp.Domain.Repository;
using RealStateApp.Infraestructure.Context;

namespace RealStateApp.Infraestructure.Repository
{
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly MongoDbContext mongoDbContext;
        public PropertyImageRepository(MongoDbContext dbContext)
        {
            mongoDbContext = dbContext;

        }

        public  async Task AddAsync(PropertyImage propertyImage)
        {
            await mongoDbContext.PropertyImages.InsertOneAsync(propertyImage);
        }

        public async Task<List<PropertyImage>> GetAllAsync()
        {
            return await mongoDbContext.PropertyImages.Find(_ => true).ToListAsync();
        }

        public async Task<PropertyImage> GetByIdAsync(string id)
        {
            return await mongoDbContext.PropertyImages
                .Find(p => p.IdPropertyImage == id)
                .FirstOrDefaultAsync();
        }

        public async Task<PropertyImage> GetFirstImageByPropertyIdAsync(string idProperty)
        {
            return await mongoDbContext.PropertyImages
                .Find(img => img.IdProperty == idProperty)
                .FirstOrDefaultAsync();
        }

        public async Task<List<PropertyImage>> GetPropertysById(string idProperty)
        {
            return await mongoDbContext.PropertyImages
                .Find(img => img.IdProperty == idProperty && img.Enabled).ToListAsync();
        }
    }
}
