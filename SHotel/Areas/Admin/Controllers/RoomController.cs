using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHotel.Business.DTOs.BedDTOs;
using SHotel.Business.DTOs.RoomDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;
using SHotel.Data.DAL;

namespace SHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]  
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IBedService _bedService;
        private readonly IMapper _mapper;
        public RoomController(IRoomService roomService, IBedService bedService, IMapper mapper)
        {
            _roomService = roomService;
            _bedService = bedService;
            _mapper = mapper;
        }

        //public IActionResult Archive()
        //{
        //    var rooms = _roomService.GetAllRooms(x=> x.IsDeleted == true);
        //    return View(rooms);

        //}

        public IActionResult Archive(int page = 1)
        {
            ViewBag.Beds = _bedService.GetAllBeds(x => x.IsDeleted == false);

            var rooms = _roomService.GetAllRooms(x => x.IsDeleted == true);

            List<Room> roomGetDto = _mapper.Map<List<Room>>(rooms);

            if (page <= 0 || page > (double)Math.Ceiling((double)roomGetDto.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Room>.Create(roomGetDto, 2, page);


            //var paginatedDatass = PaginatedList<Room>.Create(roomGetDto, 2, 1);

            //if (page*2 > paginatedDatas.Count) // 7 5
            //    return View(paginatedDatass);  

            return View(paginatedDatas);

        }

        //public IActionResult Index()
        //{
        //    ViewBag.Beds = _bedService.GetAllBeds(x=> x.IsDeleted == false);

        //    var datas = _roomService.GetAllRooms(x=> x.IsDeleted == false);

        //    return View(datas);
        //}

        public IActionResult Index(int page = 1)
        {
            ViewBag.Beds = _bedService.GetAllBeds(x => x.IsDeleted == false);

            var datas = _roomService.GetAllRooms(x => x.IsDeleted == false);

            List<Room> roomGetsDto = _mapper.Map<List<Room>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)roomGetsDto.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Room>.Create(roomGetsDto, 2, page);

            return View(paginatedDatas); 
        }


        public IActionResult Create()
        {
            ViewBag.Beds = _bedService.GetAllBeds(x => x.IsDeleted == false);


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomCreateDTO roomCreateDTO)
        {
            ViewBag.Beds = _bedService.GetAllBeds(x => x.IsDeleted == false);

            if (!ModelState.IsValid)
                return View();

            try
            {
                await _roomService.AddAsyncRoom(roomCreateDTO);
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError("RoomPosterImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.Beds = _bedService.GetAllBeds(x => x.IsDeleted == false);


            var existRoom = _roomService.GetRoom(x => x.Id == id);

            if (existRoom == null)
                return NotFound();

            var updateDto = new RoomUpdateDTO();
            updateDto.Title = existRoom.Title;
            updateDto.Description = existRoom.Description;
            updateDto.Price = existRoom.Price;
            updateDto.Size = existRoom.Size;
            updateDto.PersonCount = existRoom.PersonCount;
            updateDto.DiscountPercent = existRoom.DiscountPercent;
            updateDto.View = existRoom.View;
            updateDto.IsAvailable = existRoom.IsAvailable;
            updateDto.BedId = existRoom.BedId;
            updateDto.RoomImages = existRoom.RoomImages;
            updateDto.IsDeleted = existRoom.IsDeleted;


            return View(updateDto);
        }


        [HttpPost]
        public IActionResult Update(RoomUpdateDTO roomUpdateDTO)
        {
            ViewBag.Beds = _bedService.GetAllBeds(x => x.IsDeleted == false);


            if (!ModelState.IsValid)
                return View();

            try
            {
                _roomService.UpdateRoom(roomUpdateDTO.Id, roomUpdateDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError("RoomDetailImageFiles" , ex.Message);
                return View();
            }
            catch (FileImageSizeException ex)
            {
                ModelState.AddModelError("RoomDetailImageFiles", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            //return Ok(roomUpdateDTO.RoomImageIds);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Beds = _bedService.GetAllBeds(x => x.IsDeleted == false);

            try
            {
                _roomService.DeleteRoom(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (ImageFileNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }


    }
}
