using CarWorkShop.Domain.Entities;
using CarWorkShop.Domain.Interfaces;
using CarWorkShop.Infrastructure.Persistence;

namespace CarWorkShop.Infrastructure.Repositories
{
    public class CarWorkShopServiceRepository : ICarWorkShopServiceRepository
    {
        private readonly CarWorkShopDbContext _dbContext;

        public CarWorkShopServiceRepository(CarWorkShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(CarWorkShopService carWorkShopService)
        {
            _dbContext.Services.Add(carWorkShopService);
            await _dbContext.SaveChangesAsync();
        }
    }
}
