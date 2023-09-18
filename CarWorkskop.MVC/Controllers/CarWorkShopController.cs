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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Domain.Entities.CarWorkShop carWorkshop)
        {
            await _carWorkShopService.Create(carWorkshop);
            return RedirectToAction(nameof(Create));
        }
    }
}
