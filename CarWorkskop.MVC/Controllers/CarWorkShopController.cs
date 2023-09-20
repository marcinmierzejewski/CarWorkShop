using CarWorkShop.Application.CarWorkShop;
using CarWorkShop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkShop.MVC.Controllers
{
    public class CarWorkShopController : Controller
    {
        private readonly ICarWorkShopService _carWorkShopService;

        public CarWorkShopController(ICarWorkShopService carWorkShopService)
        {
            _carWorkShopService = carWorkShopService;
        }

        public async Task<IActionResult> Index()
        {
            var carWorkshops = await _carWorkShopService.GetAll();
            return View(carWorkshops);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarWorkShopDto carWorkshop)
        {
            if(!ModelState.IsValid)
            {
                return View(carWorkshop);
            }
            await _carWorkShopService.Create(carWorkshop);
            return RedirectToAction(nameof(Index));
        }
    }
}
