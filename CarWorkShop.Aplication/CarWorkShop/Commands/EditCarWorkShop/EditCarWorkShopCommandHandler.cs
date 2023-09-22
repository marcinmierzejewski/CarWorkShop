using CarWorkShop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.CarWorkShop.Commands.EditCarWorkShop
{
    internal class EditCarWorkShopCommandHandler : IRequestHandler<EditCarWorkShopCommand>
    {
        private readonly ICarWorkShopRepository _repository;

        public EditCarWorkShopCommandHandler(ICarWorkShopRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(EditCarWorkShopCommand request, CancellationToken cancellationToken)
        {
            var carWorkShop = await _repository.GetByEncodedName(request.EncodedName!);

            carWorkShop.Description = request.Description;
            carWorkShop.About = request.About;

            carWorkShop.ContactDetails.City = request.City;
            carWorkShop.ContactDetails.PhoneNumber = request.PhoneNumber;
            carWorkShop.ContactDetails.PostalCode = request.PostalCode;
            carWorkShop.ContactDetails.Street = request.Street;

            await _repository.Commit();

            return Unit.Value;            
        }
    }
}
