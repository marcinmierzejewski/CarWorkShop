﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.CarWorkShop.Queries.GetAllCarWorkShops
{
    public class GetAllCarWorkShopsQuery : IRequest<IEnumerable<CarWorkShopDto>>
    {
    }
}
