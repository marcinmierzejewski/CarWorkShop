using AutoMapper;
using CarWorkShop.Domain.Interfaces;
using MediatR;

namespace CarWorkShop.Application.CarWorkShop.Queries.GetAllCarWorkShops
{
    public class GetAllCarWorkShopsQueryHandler : IRequestHandler<GetAllCarWorkShopsQuery, IEnumerable<CarWorkShopDto>>
    {
        private readonly ICarWorkShopRepository _carWorkShopRepository;
        private readonly IMapper _mapper;

        public GetAllCarWorkShopsQueryHandler(ICarWorkShopRepository carWorkShopRepository, IMapper mapper)
        {
            _carWorkShopRepository = carWorkShopRepository;
            _mapper = mapper;
        } 
        public async Task<IEnumerable<CarWorkShopDto>> Handle(GetAllCarWorkShopsQuery request, CancellationToken cancellationToken)
        {
            var carWorkShops = await _carWorkShopRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CarWorkShopDto>>(carWorkShops);

            return dtos;
        }
    }
}
