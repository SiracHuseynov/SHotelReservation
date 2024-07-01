using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Abstracts;
using SHotel.Business.Services.Concretes;
using SHotel.Core.Models;
using SHotel.ViewModels;
using System.Diagnostics;

namespace SHotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IFeatureService _featureService;
        private readonly IGuestReviewService _guestReviewService;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public HomeController(ISliderService sliderService, IFeatureService featureService, IGuestReviewService guestReviewService, IRoomService roomService, IMapper mapper)
        {
            _sliderService = sliderService;
            _featureService = featureService;
            _guestReviewService = guestReviewService;
            _roomService = roomService;
            _mapper = mapper;
        }



        //public IActionResult Index(int page = 1)
        //{
        //    var datas = _roomService.GetAllRooms(x=> x.IsDeleted == false);

        //    List<Room> roomGetDtos = _mapper.Map<List<Room>>(datas);

        //    if (page <= 0 || page > (double)Math.Ceiling((double)roomGetDtos.Count / 6)) 
        //    {
        //        return RedirectToAction("Index", "ErrorPage");
        //    }

        //    var paginatedDatas = PaginatedList<Room>.Create(roomGetDtos, 6, page);

        //    //List<Room> rooms = _mapper.Map<List<Room>>(paginatedDatas);

        //    HomeViewModel homeVm = new HomeViewModel()
        //    {
        //        Sliders = _sliderService.GetAllSliders().Where(x => x.IsDeleted == false).ToList(),
        //        Features = _featureService.GetAllFeatures().Where(x => x.IsDeleted == false).ToList(),
        //        GuestReviews = _guestReviewService.GetAllGuestReviews().Where(x => x.IsDeleted == false).ToList(),
        //        PaginatedRooms = paginatedDatas
        //        //Rooms = _roomService.GetAllRooms().Where(x=> x.IsDeleted == false).ToList()


        //    };
        //    return View(homeVm);
        //}


        public IActionResult Index()
        {
            ViewBag.ProductCount = _roomService.GetAllRooms().Where(x=> x.IsDeleted == false).ToList().Count;
            HomeViewModel homeVm = new HomeViewModel()
            {
                Sliders = _sliderService.GetAllSliders().Where(x => x.IsDeleted == false).ToList(),
                Features = _featureService.GetAllFeatures().Where(x => x.IsDeleted == false).ToList(),
                GuestReviews = _guestReviewService.GetAllGuestReviews().Where(x => x.IsDeleted == false).ToList(),
                Rooms = _roomService.GetAllRooms().Where(x => x.IsDeleted == false).Take(3).ToList()

            };
            return View(homeVm);
        }

        public IActionResult LoadMore(int skip)
        {
            var rooms = _roomService.GetAllRooms()
                .Where(x => x.IsDeleted == false)
                .Skip(skip)
                .Take(3)
                .ToList();

            return PartialView("_LoadMorePartial", rooms);

        }


    }
}
