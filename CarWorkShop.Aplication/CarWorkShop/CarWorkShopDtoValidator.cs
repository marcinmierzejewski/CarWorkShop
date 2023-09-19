using CarWorkShop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.CarWorkShop
{
    public class CarWorkShopDtoValidator : AbstractValidator<CarWorkShopDto>
    {
        public CarWorkShopDtoValidator(ICarWorkShopRepository repository) 
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Name should have at least 2 characters")
                .MaximumLength(20).WithMessage("Name shold have maximum of 20 characters")
                .Custom((value, context) =>
                {
                    var existingCarWorkShop = repository.GetByName(value).Result;
                    if (existingCarWorkShop != null)
                    {
                        context.AddFailure($"{value} is not unique name for car workshop");
                    }
                });

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter description");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
