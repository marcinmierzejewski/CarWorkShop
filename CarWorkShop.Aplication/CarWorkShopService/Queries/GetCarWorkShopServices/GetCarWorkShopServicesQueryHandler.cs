using AutoMapper;
using CarWorkShop.Domain.Interfaces;
using MediatR;

namespace CarWorkShop.Application.CarWorkShopService.Queries.GetCarWorkShopServices
{
    public class GetCarWorkShopServicesQueryHandler : IRequestHandler<GetCarWorkShopServicesQuery, IEnumerable<CarWorkShopServiceDto>>
    {
        private readonly ICarWorkShopServiceRepository _carWorkShopServiceRepository;
        private readonly IMapper _mapper;

        public GetCarWorkShopServicesQueryHandler(ICarWorkShopServiceRepository carWorkShopServiceRepository, IMapper mapper)
        {
            _carWorkShopServiceRepository = carWorkShopServiceRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CarWorkShopServiceDto>> Handle(GetCarWorkShopServicesQuery request, CancellationToken cancellationToken)
        {
            var result = await _carWorkShopServiceRepository.GetAllByEncodedName(request.EncodedName);

            var dtos = _mapper.Map<IEnumerable<CarWorkShopServiceDto>>(result);

            return dtos;
        }
    }
}
