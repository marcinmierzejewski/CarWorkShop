using CarWorkShop.Application.ApplicationUser;
using CarWorkShop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.CarWorkShopService.Commands
{
    public class CreateCarWorkShopServiceCommandHandler : IRequestHandler<CreateCarWorkShopServiceCommand>
    {
        private readonly IUserContext _userContext;
        private readonly ICarWorkShopRepository _carWorkShopRepository;
        private readonly ICarWorkShopServiceRepository _carWorkShopServiceRepository;

        public CreateCarWorkShopServiceCommandHandler(IUserContext userContext, ICarWorkShopRepository carWorkShopRepository,
                ICarWorkShopServiceRepository carWorkShopServiceRepository)
        {
            _userContext = userContext;
            _carWorkShopRepository = carWorkShopRepository;
            _carWorkShopServiceRepository = carWorkShopServiceRepository;
        }
        public async Task<Unit> Handle(CreateCarWorkShopServiceCommand request, CancellationToken cancellationToken)
        {
            var carWorkShop = await _carWorkShopRepository.GetByEncodedName(request.CarWorkShopEncodedName!);

            var user = _userContext.GetCurrentUser();
            var IsEditable = user != null && (carWorkShop.CreatedById == user.Id || user.IsInRole("Mod"));

            if (!IsEditable)
            {
                return Unit.Value;
            }

            var carWorkShopService = new Domain.Entities.CarWorkShopService()
            {
                Cost = request.Cost,
                Description = request.Description,
                CarWorkShopId = carWorkShop.Id,
            };

            await _carWorkShopServiceRepository.Create(carWorkShopService);

            return Unit.Value;
        }
    }
}
