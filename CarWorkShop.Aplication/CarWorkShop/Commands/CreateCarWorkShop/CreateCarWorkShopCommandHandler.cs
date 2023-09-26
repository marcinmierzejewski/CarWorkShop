using AutoMapper;
using CarWorkShop.Application.ApplicationUser;
using CarWorkShop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.CarWorkShop.Commands.CreateCarWorkShop
{
    public class CreateCarWorkShopCommandHandler : IRequestHandler<CreateCarWorkShopCommand>
    {
        private readonly ICarWorkShopRepository _carWorkShopRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateCarWorkShopCommandHandler(ICarWorkShopRepository carWorkShopRepository, IMapper mapper, IUserContext userContext) 
        {
            _carWorkShopRepository = carWorkShopRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateCarWorkShopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkShop>(request);
            carWorkshop.EncodeName();

            carWorkshop.CreatedById = _userContext.GetCurrentUser().Id;

            await _carWorkShopRepository.Create(carWorkshop);

            return Unit.Value;
        }
    }
}
