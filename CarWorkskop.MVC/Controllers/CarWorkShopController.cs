using CarWorkShop.Application.CarWorkShop;
using CarWorkShop.Application.CarWorkShop.Commands.CreateCarWorkShop;
using CarWorkShop.Application.CarWorkShop.Queries.GetAllCarWorkShops;
using CarWorkShop.Application.CarWorkShop.Queries.GetCarWorkShopByEncodedName;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkShop.MVC.Controllers
{
    public class CarWorkShopController : Controller
    {
        private readonly IMediator _mediator;

        public CarWorkShopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var carWorkshops = await _mediator.Send(new GetAllCarWorkShopsQuery());
            return View(carWorkshops);
        }

        public IActionResult Create()
        {
            return View();
        }

        [Route("CarWorkShop/{encodeName}/Details")]
        public async Task<IActionResult> Details(string encodeName)
        {
            var dto = await _mediator.Send(new GetCarWorkShopByEncodedNameQuery(encodeName));
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarWorkShopCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
