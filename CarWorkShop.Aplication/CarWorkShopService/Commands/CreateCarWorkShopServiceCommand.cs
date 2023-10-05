using MediatR;

namespace CarWorkShop.Application.CarWorkShopService.Commands
{
    public class CreateCarWorkShopServiceCommand : CarWorkShopServiceDto, IRequest
    {
        public string CarWorkShopEncodedName { get; set; } = default!;
    }
}
