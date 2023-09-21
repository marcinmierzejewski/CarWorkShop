using AutoMapper;
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

        public CreateCarWorkShopCommandHandler(ICarWorkShopRepository carWorkShopRepository, IMapper mapper) 
        {
            _carWorkShopRepository = carWorkShopRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCarWorkShopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkShop>(request);
            carWorkshop.EncodeName();

            await _carWorkShopRepository.Create(carWorkshop);

            return Unit.Value;
        }
    }
}
