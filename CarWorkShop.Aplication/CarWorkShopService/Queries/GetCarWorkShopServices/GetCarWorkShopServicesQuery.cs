using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.CarWorkShopService.Queries.GetCarWorkShopServices
{
    public class GetCarWorkShopServicesQuery : IRequest<IEnumerable<CarWorkShopServiceDto>>
    {
        public string EncodedName { get; set; } = default!;
    }
}
