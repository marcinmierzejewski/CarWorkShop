using AutoMapper;
using CarWorkShop.Application.CarWorkShop;
using CarWorkShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.Mappings
{
    public class CarWorkShopMappingProfile : Profile
    {
        public CarWorkShopMappingProfile()
        {
            CreateMap<CarWorkShopDto, Domain.Entities.CarWorkShop>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new CarWorkShopDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                }));
        }
    }
}
