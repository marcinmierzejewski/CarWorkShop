using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.CarWorkShopService.Commands
{
    public class CreateCarWorkShopServiceCommandValidator : AbstractValidator<CreateCarWorkShopServiceCommand>
    {
        public CreateCarWorkShopServiceCommandValidator() {
            RuleFor(s => s.Cost).NotEmpty().NotNull();
            RuleFor(s => s.Description).NotEmpty().NotNull();
            RuleFor(s => s.CarWorkShopEncodedName).NotEmpty().NotNull();
        }
    }
}
