using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHotel.Business.DTOs.SliderDTOs;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;
using SHotel.Data.DAL;

namespace SHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin, SuperAdmin")]  
    public class OrderController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IReservationService _reservationService;

        public OrderController(AppDbContext appDbContext, IReservationService reservationService)
        {
            _appDbContext = appDbContext;
            _reservationService = reservationService;
        }

        //public IActionResult Index(int page = 1)
        //{
        //    var datas = _sliderService.GetAllSliders(x => x.IsDeleted == false);

        //    List<Slider> sliderGetDtos = _mapper.Map<List<Slider>>(datas);

        //    if (page <= 0 || page > (double)Math.Ceiling((double)sliderGetDtos.Count / 2))
        //    {
        //                      return RedirectToAction("Index");

        //    }

        //    var paginatedDatas = PaginatedList<Slider>.Create(sliderGetDtos, 2, page);

        //    return View(paginatedDatas);
        //}

        public async Task<IActionResult> Index(int page = 1)
        {
            var datas = await _appDbContext.Orders.ToListAsync();

            if (page <= 0 || page > (double)Math.Ceiling((double)datas.Count / 10))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Order>.Create(datas, 10, page);  

            return View(paginatedDatas);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Order order = await _appDbContext.Orders.Include(x=> x.OrderItems).FirstAsync(x=> x.Id == id);

            if(order is null)
                return NotFound();

            return View(order);
        }


        public async Task<IActionResult> Accept(int id)
        {
            Order order = await _appDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order is null)
                return NotFound();

            order.OrderStatus = Core.EnumForCore.OrderStatus.Accepted;

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Order"); 
        }

        public async Task<IActionResult> Reject(int id)
        {
            Order order = await _appDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            

            if (order is null) 
                return NotFound();

            order.OrderStatus = Core.EnumForCore.OrderStatus.Rejected;

            await _appDbContext.SaveChangesAsync();


            return RedirectToAction("Index", "Order");
        }


    }
}
