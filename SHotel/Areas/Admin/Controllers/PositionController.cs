using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHotel.Business.DTOs.PositionDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;

namespace SHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;
        public PositionController(IPositionService positionService, IMapper mapper)
        {
            _positionService = positionService;
            _mapper = mapper;
        }

        //public IActionResult Archive()
        //{
        //    var datas = _positionService.GetAllPositions(x => x.IsDeleted == true);
        //    return View(datas);
        //}

        public IActionResult Archive(int page = 1)
        {
            var datas = _positionService.GetAllPositions(x => x.IsDeleted == true);

            List<Position> positionGetDto = _mapper.Map<List<Position>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)positionGetDto.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Position>.Create(positionGetDto, 2, page);

            return View(paginatedDatas);
        }

        //public IActionResult Index()
        //{
        //    var datas = _positionService.GetAllPositions(x=> x.IsDeleted == false);
        //    return View(datas);
        //}

        public IActionResult Index(int page = 1)
        {
            var datas = _positionService.GetAllPositions(x => x.IsDeleted == false);

            List<Position> positionGetDtos = _mapper.Map<List<Position>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)positionGetDtos.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Position>.Create(positionGetDtos, 2, page);

            return View(paginatedDatas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PositionCreateDTO positionCreateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _positionService.AddAsyncPosition(positionCreateDTO);
            }
            catch (DuplicatePositionException ex)
            {
                ModelState.AddModelError("Name", ex.Message);
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
            var existPosition = _positionService.GetPosition(x=> x.Id == id);

            if (existPosition == null)
                return NotFound();

            var position = new PositionUpdateDTO();
            position.Name = existPosition.Name;
            position.IsDeleted = existPosition.IsDeleted;


            return View(position); 
        }

        [HttpPost]
        public IActionResult Update(PositionUpdateDTO positionUpdateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _positionService.UpdatePosition(positionUpdateDTO.Id, positionUpdateDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (DuplicatePositionException ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            try
            {
                _positionService.DeletePosition(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }


    }
}
