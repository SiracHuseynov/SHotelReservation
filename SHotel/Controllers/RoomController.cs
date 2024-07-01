using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SHotel.Business.DTOs.ReservationDTOs;
using SHotel.Business.DTOs.RoomDTOs;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Abstracts;
using SHotel.Business.Services.Concretes;
using SHotel.Core.Models;
using SHotel.Core.RepositoryAbstracts;
using SHotel.Data.DAL;
using SHotel.ViewModels;
using System.Linq;

namespace SHotel.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IReservationService _reservationService;
        private readonly AppDbContext _appDbContext;
        private readonly IBasketItemService _basketItemService;
        public RoomController(IRoomService roomService, IMapper mapper, IRoomRepository roomRepository, IReservationService reservationService, UserManager<AppUser> userManager, AppDbContext appDbContext, IBasketItemService basketItemService)
        {
            _roomService = roomService;
            _mapper = mapper;
            _roomRepository = roomRepository;
            _reservationService = reservationService;
            _userManager = userManager;
            _appDbContext = appDbContext;
            _basketItemService = basketItemService;
        }

        public IActionResult Index(string? search, int? minPrice, int? maxPrice, int? personCount, DateTime? arrive, DateTime? departure, int page = 1)
        {
            var rooms = _roomService.GetAllRooms(x => x.IsDeleted == false).AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                rooms = rooms.Where(x => x.Title.ToLower().Contains(search.ToLower()));
            }

            ViewBag.search = search;
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

            //List<Room> rooms = _mapper.Map<List<Room>>(paginatedDatas);

            RoomViewModel roomViewModel = new RoomViewModel()
            {
                PaginatedRooms = paginatedDatas,
                //Rooms = _roomService.GetAllRooms(x => x.IsDeleted == false),
            };

            return View(roomViewModel);
        }

        [HttpPost]
        public IActionResult RoomDetail(DateTime? departure, int id, DateTime? arrive, int page = 1)
        {
            if (!ModelState.IsValid)
                return View();

            var room = _roomService.GetRoom(x => x.Id == id);


            var datas = _roomService.GetAllRooms(x => x.IsDeleted == false);

            List<Room> roomGetDtos = _mapper.Map<List<Room>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)roomGetDtos.Count / 4))
            {
                return RedirectToAction("Index", "ErrorPage");
            }

            var paginatedDatas = PaginatedList<Room>.Create(roomGetDtos, 4, page);

            RoomViewModel roomViewModel = new RoomViewModel()
            {
                Room = room,
                PaginatedRooms = paginatedDatas,


            };

            if (arrive.HasValue && departure.HasValue)
            {
                if (room.Reservations.Any(reservation => reservation.StartDate <= departure && reservation.EndDate > arrive))
                {
                    ModelState.AddModelError("", "reserv var!");
                    return View(roomViewModel);
                }

            }



            return RedirectToAction("RoomDetail", "Room", id);
        }

        public IActionResult RoomDetail(DateTime? arrive, DateTime? departure, int id, int page = 1)
        {

            var existRoom = _roomService.GetRoom(x => x.Id == id && x.IsDeleted == false);

            if (existRoom == null)
                return NotFound();



            var datas = _roomService.GetAllRooms(x => x.IsDeleted == false);

            List<Room> roomGetDtos = _mapper.Map<List<Room>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)roomGetDtos.Count / 4))
            {
                return RedirectToAction("Index", "ErrorPage");
            }

            var paginatedDatas = PaginatedList<Room>.Create(roomGetDtos, 4, page);

            RoomViewModel roomViewModel = new RoomViewModel()
            {
                PaginatedRooms = paginatedDatas,
                //Rooms = _roomService.GetAllRooms(x => x.IsDeleted == false),
                Room = existRoom
            };

            return View(roomViewModel);
        }




        //rezerv Start 18.06.2024 - Leave 22.06.2024    //yoxlaFirst 17.06.2024 - 20.06.2024    //yoxlaSecond 19.06.2024 - 21.06.2024    //yoxlaThree 20.06.2024 - 23.06.2024

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

        public async Task<IActionResult> AddToBasket(int roomId, DateTime arrive, DateTime departure)
        {
            var room = _roomService.GetRoom(x => x.Id == roomId);

            if (room.Reservations.Any(reservation => reservation.StartDate <= departure && reservation.EndDate > arrive))
            {
                ModelState.AddModelError("", "Rezerv var!");
                return View();
            }
           
            //Baxarsan 

            //ModelState.AddModelError("", "Otagda rezerv yoxdur!");
            //return View();

            List<BasketItemViewModel> basketItems = new List<BasketItemViewModel>();

            BasketItemViewModel basketItem = new BasketItemViewModel()
            {
                RoomId = roomId,
                Arrive = arrive,
                Departure = departure,
                DayCount = departure.Subtract(arrive).Days
            };

            //RoomGetDTO room = _roomService.GetRoom(x => x.Id == roomId);

            if (room == null) return NotFound();

            List<BasketItemViewModel> BasketItemViewModels = new List<BasketItemViewModel>();
            BasketItemViewModel BasketItemViewModel = null;
            BasketItem userBasketItem = null;
            AppUser user = null;

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            }



            if (user == null)
            {
                string basketItemsStr = HttpContext.Request.Cookies["BasketItems"];

                // Ensure the cookie is a JSON array
                if (string.IsNullOrEmpty(basketItemsStr))
                {
                    BasketItemViewModels = new List<BasketItemViewModel>();
                }
                else
                {
                    try
                    {
                        BasketItemViewModels = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(basketItemsStr);
                    }
                    catch (JsonSerializationException ex)
                    {
                        // Log the exception and return an error response
                        Console.WriteLine("Error deserializing cookie: " + ex.Message);
                        return BadRequest("Invalid cookie format");
                    }
                }

                BasketItemViewModel = BasketItemViewModels.FirstOrDefault(x => x.RoomId == roomId);

                BasketItemViewModel = new BasketItemViewModel()
                {
                    RoomId = roomId,
                    Arrive = arrive,
                    Departure = departure,
                    DayCount = departure.Subtract(arrive).Days
                };

                BasketItemViewModels.Add(BasketItemViewModel);

                basketItemsStr = JsonConvert.SerializeObject(BasketItemViewModels);

                HttpContext.Response.Cookies.Append("BasketItems", basketItemsStr);
            }
            else
            {
                userBasketItem = _basketItemService.GetBasketItem(x => x.RoomId == roomId &&
                x.AppUserId == user.Id && !x.IsDeleted);
                if (userBasketItem != null)
                {
                    RedirectToAction("Index", "Room");
                }
                else
                {
                    userBasketItem = new BasketItem
                    {
                        RoomId = roomId,
                        DayCount = departure.Subtract(arrive).Days,
                        Arrive = arrive,
                        Departure = departure,
                        AppUserId = user.Id,
                        IsDeleted = false,
                    };
                    await _basketItemService.AddAsyncBasketItem(userBasketItem);
                }

            }




            return Ok();





        }






    }
}
