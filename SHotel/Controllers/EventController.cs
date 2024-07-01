using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SHotel.Business.DTOs.AdventureDTOs;
using SHotel.Business.DTOs.RoomDTOs;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;
using SHotel.Data.DAL;
using SHotel.ViewModels;

namespace SHotel.Controllers
{
    public class EventController : Controller
    {
        private readonly IAdventureService _adventureService;
        private readonly IAdventureCategoryService _adventureCategoryService;
        private readonly AppDbContext _context;
        private readonly ISettingService _settingService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public EventController(IAdventureService adventureService, IAdventureCategoryService adventureCategoryService, AppDbContext context, ISettingService settingService, IMapper mapper, AppDbContext appDbContext)
        {
            _adventureService = adventureService;
            _adventureCategoryService = adventureCategoryService;
            _context = context;
            _settingService = settingService;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }



        public async Task<List<Setting>> GetSetting()
        {
            var settings = _context.Settings.ToList();
            return settings;
        }
        public IActionResult Events(int? categoryId,int page = 1) 
        {
            var datas = _adventureService.GetAllAdventures(x=> x.IsDeleted == false);

            ViewBag.categoryId = categoryId;

            List<Adventure> adventureGetDtos = _mapper.Map<List<Adventure>>(datas);

            if(categoryId != null)
            {
                adventureGetDtos = adventureGetDtos.Where(x=> x.AdventureCategoryId == categoryId).ToList();
            }

            if (page <= 0 || page > (double)Math.Ceiling((double)adventureGetDtos.Count / 2))
            {
                return RedirectToAction("Index", "ErrorPage");
            }


            var paginatedDatas = PaginatedList<Adventure>.Create(adventureGetDtos, 2, page); 

            EventViewModel eventViewModel = new EventViewModel()
            {
                Adventures = _adventureService.GetAllAdventures(x=> x.IsDeleted == false),
                AdventureCategories = _adventureCategoryService.GetAllAdventureCategories(x=> x.IsDeleted == false),
                PaginatedAdventures = paginatedDatas
            };

            return View(eventViewModel);
        }


        public IActionResult EventsDetail(int commentId,int id, int? categoryId)
        {
            var datas = _adventureService.GetAllAdventures(x => x.IsDeleted == false);

            if (categoryId != null)
            {
                datas = datas.Where(x => x.AdventureCategoryId == categoryId).ToList();
            }

            EventViewModel eventViewModel = new EventViewModel()
            {
                Adventures = datas,
                AdventureCategories = _adventureCategoryService.GetAllAdventureCategories(x => x.IsDeleted == false),
                Adventure = _adventureService.GetAdventure(x=> x.Id == id),
            };


            return View(eventViewModel);
        }

    




    }
}
