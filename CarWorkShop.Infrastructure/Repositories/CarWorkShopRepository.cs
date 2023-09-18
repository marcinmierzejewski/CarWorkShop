using CarWorkShop.Domain.Interfaces;
using CarWorkShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Infrastructure.Repositories
{
    internal class CarWorkShopRepository : ICarWorkShopRepository
    {
        private readonly CarWorkShopDbContext _dbContext;

        public CarWorkShopRepository(CarWorkShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Domain.Entities.CarWorkShop carWorkshop)
        {
            _dbContext.Add(carWorkshop);
            await _dbContext.SaveChangesAsync();
        }
    }
}
