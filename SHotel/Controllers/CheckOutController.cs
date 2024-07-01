using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SHotel.Business.DTOs.ReservationDTOs;
using SHotel.Business.DTOs.RoomDTOs;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;
using SHotel.Data.DAL;
using SHotel.ViewModels;
using Stripe;
using System.Diagnostics.Metrics;

namespace SHotel.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IBasketItemService _basketItemService;
        private readonly IReservationService _reservationService;

        public CheckOutController(IRoomService roomService, UserManager<AppUser> userManager, AppDbContext appDbContext, IMapper mapper, IBasketItemService basketItemService, IReservationService reservationService)
        {
            _roomService = roomService;
            _userManager = userManager;
            _appDbContext = appDbContext;
            _mapper = mapper;
            _basketItemService = basketItemService;
            _reservationService = reservationService;
        }

        public async Task<IActionResult> Index()
        {
            List<CheckOutViewModel> checkOutVms = new List<CheckOutViewModel>();
            List<BasketItemViewModel> basketItemVms = new List<BasketItemViewModel>();
            List<BasketItem> userBasketItems = new List<BasketItem>();
            CheckOutViewModel checkOutVm = null;
            AppUser user = null;

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            }

            if (user == null)
            {
                string basketItemsStr = HttpContext.Request.Cookies["BasketItems"];

                if (basketItemsStr != null)
                {
                    basketItemVms = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(basketItemsStr);

                    foreach (var item in basketItemVms)
                    {
                        checkOutVm = new CheckOutViewModel
                        {
                            Room = _roomService.GetRoom(x => x.Id == item.RoomId),
                            ArriveDate = item.Arrive,
                            DepartureDate = item.Departure,
                            //DayCount = item.Departure.Subtract(item.Arrive).Days
                            DayCount = item.DayCount,
                        };

                        checkOutVms.Add(checkOutVm);

                    }

                }

            }
            else
            {
                userBasketItems = _basketItemService.GetAllBasketItems(x => x.AppUserId ==
                user.Id && !x.IsDeleted).ToList();

                foreach (var item in userBasketItems)
                {
                    checkOutVm = new CheckOutViewModel
                    {
                        Room = _roomService.GetRoom(x => x.Id == item.RoomId),
                        ArriveDate = item.Arrive,
                        DepartureDate = item.Departure,
                        //DayCount = item.Departure.Subtract(item.Arrive).Days
                        DayCount = item.DayCount,
                    };
                    checkOutVms.Add(checkOutVm);
                }

            }

            OrderViewModel orderViewModel = new OrderViewModel
            {
                //CheckOutViewModels = checkOutVms,
                Name = user?.Name,
                Surname = user?.Surname,
            };

            ViewBag.CheckOutViewModel = checkOutVms;

            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(OrderViewModel orderViewModel, string stripeEmail, string stripeToken)
        {
            List<CheckOutViewModel> checkOutVms = new List<CheckOutViewModel>();

            List<BasketItemViewModel> basketItemVms = new List<BasketItemViewModel>();
            List<BasketItem> userBasketItems = new List<BasketItem>();
            CheckOutViewModel checkOutVm = null;
            OrderItem orderItem = null;
            AppUser user = null;
            Reservation reservation = null;
            ReservationCreateDTO reservationCreateDTO = null;
            int count = 1;

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            }

            Order order = new Order
            {
                Name = orderViewModel.Name,
                Surname = orderViewModel.Surname,
                Address = orderViewModel.Address,
                Country = orderViewModel.Country,
                Email = orderViewModel.Email,
                Phone = orderViewModel.Phone,
                ZipCode = orderViewModel.ZipCode,
                Note = orderViewModel.Note,
                OrderItems = new List<OrderItem>(),
                AppUserId = user?.Id,
                CreatedDate = DateTime.UtcNow.AddHours(4)
            };


            order.OrderItems = new List<OrderItem>();

            if (user == null)
            {
                string basketItemsStr = HttpContext.Request.Cookies["BasketItems"];

                if (basketItemsStr != null)
                {
                    basketItemVms = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(basketItemsStr);


                    order.TotalPrice = 0;
                    foreach (var item in basketItemVms)
                    {
                        checkOutVm = new CheckOutViewModel
                        {
                            Room = _roomService.GetRoom(x => x.Id == item.RoomId),
                            //DayCount = item.Departure.Subtract(item.Arrive).Days
                            DayCount = item.DayCount,
                        };
                        checkOutVms.Add(checkOutVm);
                        //RoomGetDTO roomGetDTO = _roomService.GetRoom(x => x.Id == item.RoomId);
                        //Room room = _mapper.Map<Room>(roomGetDTO);
                        Room room = _appDbContext.Rooms.FirstOrDefault(x => x.Id == item.RoomId);
                        orderItem = new OrderItem
                        {
                            Room = room,
                            RoomName = room.Title,
                            DiscountPercent = room.DiscountPercent,
                            //DayCount = item.Departure.Subtract(item.Arrive).Days, //meselen bunu duzelt
                            DayCount = item.DayCount,
                            Order = order
                        };

                        if (room.DiscountPercent is null)
                            orderItem.Price = room.Price;
                        else
                            orderItem.Price = room.Price - room.Price * room?.DiscountPercent / 100;

                        order.TotalPrice += orderItem.Price * orderItem.DayCount;
                        order.OrderItems.Add(orderItem);

                        //reservation = new Reservation
                        //{
                        //    StartDate = item.Arrive,
                        //    EndDate = item.Departure,
                        //    RoomId = room.Id,
                        //    CreatedDate = DateTime.Now.AddHours(4)
                        //};



                        //reservationCreateDTO = _mapper.Map<ReservationCreateDTO>(reservation);
                        //await _reservationService.AddAsyncReservation(reservationCreateDTO);


                    }
                    //if (ModelState.IsValid)
                    //    HttpContext.Response.Cookies.Delete("BasketItems");
                    //else
                    //{
                    //    ViewBag.CheckOutViewModel = checkOutVms;
                    //    return View();
                    //}

                }
            }
            else
            {
                userBasketItems = _basketItemService.GetAllBasketItems(x => x.AppUserId ==
                    user.Id && x.IsDeleted == false).ToList();
                order.TotalPrice = 0;

                foreach (var item in userBasketItems)
                {
                    checkOutVm = new CheckOutViewModel
                    {
                        Room = _roomService.GetRoom(x => x.Id == item.RoomId),

                        //DayCount = item.Departure.Subtract(item.Arrive).Days
                        DayCount = item.DayCount,
                    };
                    checkOutVms.Add(checkOutVm);
                    //RoomGetDTO roomGetDTO = _roomService.GetRoom(x => x.Id == item.RoomId); 
                    //Room room = _mapper.Map<Room>(roomGetDTO);

                    Room room = _appDbContext.Rooms.FirstOrDefault(x => x.Id == item.RoomId);

                    orderItem = new OrderItem
                    {
                        Room = room,
                        RoomName = room.Title,
                        DiscountPercent = room.DiscountPercent,
                        //DayCount = item.Departure.Subtract(item.Arrive).Days, //meselen bunu duzelt
                        DayCount = item.DayCount,
                        Order = order
                    };



                    if (room.DiscountPercent is null)
                        orderItem.Price = room.Price;
                    else
                        orderItem.Price = room.Price - room.Price * room?.DiscountPercent / 100;

                    order.TotalPrice += orderItem.Price * orderItem.DayCount;
                    order.OrderItems.Add(orderItem);
                    item.IsDeleted = true;

                    //reservation = new Reservation
                    //{
                    //    StartDate = item.Arrive,
                    //    EndDate = item.Departure,
                    //    RoomId = room.Id,
                    //    CreatedDate = DateTime.Now.AddHours(4),
                    //    UserId = user.Id,
                    //};



                    // reservationCreateDTO = _mapper.Map<ReservationCreateDTO>(reservation);
                    // await _reservationService.AddAsyncReservation(reservationCreateDTO);

                }



            }

            //TODO Stripe
            ViewBag.CheckOutViewModel = checkOutVms;

            if (!ModelState.IsValid)
                return View();

            var optionCust = new CustomerCreateOptions
            {
                Email = stripeEmail,
                Name = orderViewModel.Name + " " + orderViewModel.Surname,
                Phone = orderViewModel.Phone
            };
            var serviceCust = new CustomerService();
            Customer customer = serviceCust.Create(optionCust);

            order.TotalPrice = order.TotalPrice * 100;
            var optionsCharge = new ChargeCreateOptions
            {

                Amount = (long)order.TotalPrice,
                Currency = "USD",
                Description = "Room Reservation amount",
                Source = stripeToken,
                ReceiptEmail = stripeEmail


            };

            var serviceCharge = new ChargeService();
            Charge charge = serviceCharge.Create(optionsCharge);
            if (charge.Status != "succeeded")
            {
                ViewBag.CheckOutViewModel = checkOutVms;
                ModelState.AddModelError("", "Odenishde problem var");
                return View();
            }


            order.TotalPrice = order.TotalPrice / 100;


            if (user != null)
            {
                foreach (var item in userBasketItems)
                {
                    checkOutVm = new CheckOutViewModel
                    {
                        Room = _roomService.GetRoom(x => x.Id == item.RoomId),
                        DayCount = item.DayCount,
                    };

                    Room room = _appDbContext.Rooms.FirstOrDefault(x => x.Id == item.RoomId);

                    reservation = new Reservation
                    {
                        StartDate = item.Arrive,
                        EndDate = item.Departure,
                        RoomId = room.Id,
                        CreatedDate = DateTime.Now.AddHours(4),
                        UserId = user.Id,
                    };



                    reservationCreateDTO = _mapper.Map<ReservationCreateDTO>(reservation);
                    await _reservationService.AddAsyncReservation(reservationCreateDTO);

                }
            }
            else
            {
                foreach (var item in basketItemVms)
                {
                    checkOutVm = new CheckOutViewModel
                    {
                        Room = _roomService.GetRoom(x => x.Id == item.RoomId),
                        DayCount = item.DayCount,
                    };
                    Room room = _appDbContext.Rooms.FirstOrDefault(x => x.Id == item.RoomId);
                  
                    reservation = new Reservation
                    {
                        StartDate = item.Arrive,
                        EndDate = item.Departure,
                        RoomId = room.Id,
                        CreatedDate = DateTime.Now.AddHours(4)
                    };

                    reservationCreateDTO = _mapper.Map<ReservationCreateDTO>(reservation);
                    await _reservationService.AddAsyncReservation(reservationCreateDTO);


                }
                if (ModelState.IsValid)
                    HttpContext.Response.Cookies.Delete("BasketItems");
                else
                {
                    ViewBag.CheckOutViewModel = checkOutVms;
                    return View();
                }
            }


            await _appDbContext.Orders.AddAsync(order);



            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }




        [HttpPost]
        public async Task<IActionResult> RemoveItem(int roomId)
        {
            AppUser user = null;


            if (HttpContext.User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            }

            if (user == null)
            {
                // Unauthenticated user
                var baskets = HttpContext.Request.Cookies["BasketItems"];
                if (baskets != null)
                {
                    var rooms = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(baskets);
                    var itemToRemove = rooms.FirstOrDefault(x => x.RoomId == roomId);
                    if (itemToRemove != null)
                    {
                        rooms.Remove(itemToRemove);
                        var updatedBasket = JsonConvert.SerializeObject(rooms);
                        HttpContext.Response.Cookies.Append("BasketItems", updatedBasket);
                    }
                }
            }
            else
            {

                _basketItemService.DeleteBasketItem(roomId, user.Id); 
            }

            return Ok();
        }




















    }
}