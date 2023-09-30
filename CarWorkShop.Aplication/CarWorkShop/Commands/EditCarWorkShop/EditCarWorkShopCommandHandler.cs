using CarWorkShop.Application.ApplicationUser;
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
        private readonly IUserContext _userContext;

        public EditCarWorkShopCommandHandler(ICarWorkShopRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditCarWorkShopCommand request, CancellationToken cancellationToken)
        {
            var carWorkShop = await _repository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var IsEditable = user != null && carWorkShop.CreatedById == user.Id;

            if (!IsEditable)
            {
                return Unit.Value;
            }

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
