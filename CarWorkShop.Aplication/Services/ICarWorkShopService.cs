namespace CarWorkShop.Application.Services
{
    public interface ICarWorkShopService
    {
        Task Create(Domain.Entities.CarWorkShop carWorkshop);
    }
}