using Microsoft.AspNetCore.Mvc;
using SHotel.Business.Services.Abstracts;
using SHotel.ViewModels;

namespace SHotel.Controllers
{
    public class RestoranController : Controller
    {
        private readonly IEatService _eatService;
        private readonly IEatCategoryService _eatCategoryService;
        private readonly IAdventureService _adventureService;
        public RestoranController(IEatService eatService, IEatCategoryService eatCategoryService, IAdventureService adventureService)
        {
            _eatService = eatService;
            _eatCategoryService = eatCategoryService;
            _adventureService = adventureService;
        }

        public IActionResult Index(int id) 
        {
            RestoranViewModel restoranViewModel = new RestoranViewModel()
            {
                EatCategories = _eatCategoryService.GetAllEatCategories().Where(x=> x.IsDeleted == false).ToList(),
                Eats = _eatService.GetAllEats().Where(x=> x.IsDeleted==false).ToList(),
                Adventures = _adventureService.GetAllAdventures(x=> x.IsDeleted == false).ToList()
            };
            return View(restoranViewModel);
        }

    }
}
