using CarWorkShop.Application.CarWorkShop;

namespace CarWorkShop.Application.Services
{
    public interface ICarWorkShopService
    {
        Task Create(CarWorkShopDto carWorkshop);
    }
}