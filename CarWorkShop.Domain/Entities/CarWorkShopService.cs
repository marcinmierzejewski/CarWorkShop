﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Domain.Entities
{
    public class CarWorkShopService
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
        public string Cost { get; set; } = default!;

        public int CarWorkShopId { get; set; } = default!;
        public CarWorkShop CarWorkShop { get; set; } = default!;

    }
}
