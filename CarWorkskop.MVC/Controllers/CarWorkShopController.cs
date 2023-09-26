﻿using AutoMapper;
using CarWorkShop.Application.CarWorkShop;
using CarWorkShop.Application.CarWorkShop.Commands.CreateCarWorkShop;
using CarWorkShop.Application.CarWorkShop.Commands.EditCarWorkShop;
using CarWorkShop.Application.CarWorkShop.Queries.GetAllCarWorkShops;
using CarWorkShop.Application.CarWorkShop.Queries.GetCarWorkShopByEncodedName;
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

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCarWorkShopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
