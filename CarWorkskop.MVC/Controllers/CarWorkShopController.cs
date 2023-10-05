using AutoMapper;
using CarWorkShop.Application.CarWorkShop;
using CarWorkShop.Application.CarWorkShop.Commands.CreateCarWorkShop;
using CarWorkShop.Application.CarWorkShop.Commands.EditCarWorkShop;
using CarWorkShop.Application.CarWorkShop.Queries.GetAllCarWorkShops;
using CarWorkShop.Application.CarWorkShop.Queries.GetCarWorkShopByEncodedName;
using CarWorkShop.Application.CarWorkShopService.Commands;
using CarWorkShop.Application.CarWorkShopService.Queries.GetCarWorkShopServices;
using CarWorkShop.MVC.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkShop.MVC.Controllers
{
    public class CarWorkShopController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CarWorkShopController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var carWorkshops = await _mediator.Send(new GetAllCarWorkShopsQuery());
            return View(carWorkshops);
        }

        [Route("CarWorkShop/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetCarWorkShopByEncodedNameQuery(encodedName));
            return View(dto);
        }

        [Route("CarWorkShop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetCarWorkShopByEncodedNameQuery(encodedName));
            
            if(!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditCarWorkShopCommand model = _mapper.Map<EditCarWorkShopCommand>(dto);
            return View(model);
        }

        [HttpPost]
        [Route("CarWorkShop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditCarWorkShopCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Owner")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> Create(CreateCarWorkShopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotification("success", $"Created carworkshop: {command.Name}");

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = "Owner")]
        [Route("CarWorkShop/CarWorkShopService")]
        public async Task<IActionResult> CreateCarWorkShopService(CreateCarWorkShopServiceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        [Route("CarWorkShop/{encodedName}/CarWorkShopService")]
        public async Task<IActionResult> GetCarWorkShopServices(string encodedName)
        {
            var data = await _mediator.Send(new GetCarWorkShopServicesQuery() { EncodedName = encodedName });
            return Ok(data);
        }
    }
}
