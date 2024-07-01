using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SHotel.Business.DTOs.RoomDTOs;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;
using SHotel.ViewModels;

namespace SHotel.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        public ReservationController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        public IActionResult Index(int? minPrice, int? maxPrice, int? personCount, DateTime? arrive, DateTime? departure, int page = 1)
        {
            var rooms = _roomService.GetAllRooms(x => x.IsDeleted == false).AsQueryable();

            ViewBag.minPrice = minPrice;
            ViewBag.maxPrice = maxPrice;
            ViewBag.personCount = personCount;
            ViewBag.arrive = arrive;
            ViewBag.departure = departure;

            if (minPrice.HasValue)
            {
                rooms = rooms.Where(x => (x.DiscountPercent == null ? x.Price : (x.Price - x.Price * x.DiscountPercent / 100)) >= minPrice);
            }

            if (maxPrice.HasValue)
            {
                rooms = rooms.Where(x => (x.DiscountPercent == null ? x.Price : (x.Price - x.Price * x.DiscountPercent / 100)) <= maxPrice);
            }

            if (personCount.HasValue)
            {
                rooms = rooms.Where(x => x.PersonCount == personCount);
            }

            if (arrive.HasValue && departure.HasValue)
            {
                rooms = rooms.Where(room => !room.Reservations.Any(reservation =>
                    (reservation.StartDate <= departure && reservation.EndDate > arrive)
                ));
            }

            //var datas = _roomService.GetAllRooms(x => x.IsDeleted == false);

            List<Room> roomGetDtos = _mapper.Map<List<Room>>(rooms);

            if (page <= 0 || page > (double)Math.Ceiling((double)roomGetDtos.Count / 2))                                                                          
            {
                return RedirectToAction("Index", "ErrorPage");               
            }

            var paginatedDatas = PaginatedList<Room>.Create(roomGetDtos, 2, page);

            RoomViewModel roomViewModel = new RoomViewModel()
            {
                PaginatedRooms = paginatedDatas,
                //Rooms = _roomService.GetAllRooms(x=> x.IsDeleted == false),
            };
            return View(roomViewModel);
        }

        //public IActionResult Search(string? search, int? minPrice, int? maxPrice, int? personCount, DateTime? arrive, DateTime? departure)
        //{
        //    var rooms = _roomService.GetAllRooms(x => x.IsDeleted == false).AsQueryable();

        //    if (!string.IsNullOrEmpty(search))
        //    {
        //        rooms = rooms.Where(x => x.Title.ToLower().Contains(search.ToLower()));
        //    }

        //    if (minPrice.HasValue)
        //    {
        //        rooms = rooms.Where(x => (x.DiscountPercent == null ? x.Price : (x.Price - x.Price * x.DiscountPercent / 100)) >= minPrice);
        //    }

        //    if (maxPrice.HasValue)
        //    {
        //        rooms = rooms.Where(x => (x.DiscountPercent == null ? x.Price : (x.Price - x.Price * x.DiscountPercent / 100)) <= maxPrice);
        //    }

        //    if (personCount.HasValue)
        //    {
        //        rooms = rooms.Where(x => x.PersonCount == personCount);
        //    }

        //    if (arrive.HasValue && departure.HasValue)
        //    {
        //        rooms = rooms.Where(room => !room.Reservations.Any(reservation =>
        //            (reservation.StartDate <= departure && reservation.EndDate > arrive)
        //        ));
        //    }


        //    List<RoomGetDTO> roomGetDTOs = _mapper.Map<List<RoomGetDTO>>(rooms);

        //    RoomViewModel roomsViewModel = new RoomViewModel()
        //    {
        //        Rooms = roomGetDTOs,
        //    };

        //    return View(roomsViewModel); 
        //}

        //public IActionResult Search(int? minPrice, int? maxPrice, int? personCount, DateTime? arrive, DateTime? departure)
        //{
        //    var rooms = _roomService.GetAllRooms(x => x.IsDeleted == false).AsQueryable();

        //    if (minPrice.HasValue)
        //    {
        //        rooms = rooms.Where(x => (x.DiscountPercent == null ? x.Price : (x.Price - x.Price * x.DiscountPercent / 100)) >= minPrice);
        //    }

        //    if (maxPrice.HasValue)
        //    {
        //        rooms = rooms.Where(x => (x.DiscountPercent == null ? x.Price : (x.Price - x.Price * x.DiscountPercent / 100)) <= maxPrice);
        //    }

        //    if (personCount.HasValue)
        //    {
        //        rooms = rooms.Where(x => x.PersonCount == personCount);
        //    }

        //    if (arrive.HasValue && departure.HasValue)
        //    {
        //        rooms = rooms.Where(room => !room.Reservations.Any(reservation =>
        //            (reservation.StartDate <= departure && reservation.EndDate >= arrive)
        //        ));
        //    }


        //    List<RoomGetDTO> roomGetDTOs = _mapper.Map<List<RoomGetDTO>>(rooms);

        //    RoomViewModel roomsViewModel = new RoomViewModel()
        //    {
        //        Rooms = roomGetDTOs,
        //    };

        //    return View(roomsViewModel);
        //}


        //public IActionResult RoomDetail(int id)
        //{
        //    RoomViewModel roomViewModel = new RoomViewModel()
        //    {
        //        Rooms = _roomService.GetAllRooms(x => x.IsDeleted == false),
        //        Room = _roomService.GetRoom(x => x.Id == id && x.IsDeleted == false)
        //    };


        //    return View(roomViewModel);
        //}
    }
}
