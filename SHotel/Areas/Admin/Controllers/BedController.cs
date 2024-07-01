using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHotel.Business.DTOs.BedDTOs;
using SHotel.Business.DTOs.EatDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;
using System.Collections.Generic;

namespace SHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class BedController : Controller
    {
        private readonly IBedService _bedService;
        private readonly IMapper _mapper;
        public BedController(IBedService bedService, IMapper mapper)
        {
            _bedService = bedService;
            _mapper = mapper;
        }

        //public IActionResult Archive()
        //{
        //    var datas = _bedService.GetAllBeds(x=> x.IsDeleted == true);
        //    return View(datas);
        //}

        public IActionResult Archive(int page = 1)
        {
            var datas = _bedService.GetAllBeds(x => x.IsDeleted == true);

            List<Bed> bedGetDtos = _mapper.Map<List<Bed>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)bedGetDtos.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Bed>.Create(bedGetDtos, 2, page);

            return View(paginatedDatas);  
        }

        //public IActionResult Index()
        //{
        //    var datas = _bedService.GetAllBeds(x => x.IsDeleted == false); 
        //    return View(datas);
        //}

        public IActionResult Index(int page = 1)
        {
            var datas = _bedService.GetAllBeds(x => x.IsDeleted == false);

            List<Bed> bedGetDtos = _mapper.Map<List<Bed>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)bedGetDtos.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Bed>.Create(bedGetDtos, 2, page);

            return View(paginatedDatas); 
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BedCreateDTO bedCreateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _bedService.AddAsyncBed(bedCreateDTO);
            }
            catch (DuplicateBedException ex)
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
            var existBed = _bedService.GetBed(x=> x.Id == id);

            if (existBed == null)
                return NotFound();

            var updateDto = new BedUpdateDTO();
            updateDto.Name = existBed.Name;
            updateDto.IsDeleted = existBed.IsDeleted;

            return View(updateDto);
        }

        [HttpPost]
        public IActionResult Update(BedUpdateDTO bedUpdateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _bedService.UpdateBed(bedUpdateDTO.Id, bedUpdateDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (DuplicateBedException ex)
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
                _bedService.DeleteBed(id);
            }
            catch (EntityNotFoundException ex)
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
