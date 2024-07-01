using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHotel.Business.DTOs.AdventureDTOs;
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

    public class AdventureController : Controller
    {
        private readonly IAdventureService _adventureService;
        private readonly IAdventureCategoryService _adventureCategoryService;
        private readonly IMapper _mapper;
        public AdventureController(IAdventureService adventureService, IAdventureCategoryService adventureCategoryService, IMapper mapper)
        {
            _adventureService = adventureService;
            _adventureCategoryService = adventureCategoryService;
            _mapper = mapper;
        }

        public IActionResult Archive(int page = 1) 
        {
            ViewBag.AdventureCategories = _adventureCategoryService.GetAllAdventureCategories(x => x.IsDeleted == false);

            var datas = _adventureService.GetAllAdventures(x => x.IsDeleted == true);

            List<Adventure> adventureGetDtos = _mapper.Map<List<Adventure>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)adventureGetDtos.Count / 6))
            {
                return RedirectToAction("Index");
            }

            var paginatedDatas = PaginatedList<Adventure>.Create(adventureGetDtos, 6, page);

            return View(paginatedDatas);
        }

        public IActionResult Index(int page = 1)
        {
            ViewBag.AdventureCategories = _adventureCategoryService.GetAllAdventureCategories(x=> x.IsDeleted == false);

            var datas = _adventureService.GetAllAdventures(x=> x.IsDeleted == false);

            List<Adventure> adventureGetDtos = _mapper.Map< List<Adventure>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)adventureGetDtos.Count / 6))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Adventure>.Create(adventureGetDtos, 6, page);

            return View(paginatedDatas);
        }

        public IActionResult Create()
        {
            ViewBag.AdventureCategories = _adventureCategoryService.GetAllAdventureCategories(x => x.IsDeleted == false);
            return View();      
        }

        [HttpPost]
        public IActionResult Create(AdventureCreateDTO adventureCreateDTO)
        {
            ViewBag.AdventureCategories = _adventureCategoryService.GetAllAdventureCategories(x => x.IsDeleted == false);

            if (!ModelState.IsValid)
                return View();

            try
            {
                _adventureService.AddAsyncAdventure(adventureCreateDTO);
            }
            catch (ImageFileNotFoundException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (FileImageSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
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
            ViewBag.AdventureCategories = _adventureCategoryService.GetAllAdventureCategories(x => x.IsDeleted == false);

            var existAdventure = _adventureService.GetAdventure(x => x.Id == id);

            if (existAdventure == null)
                return NotFound();

            var updateDto = new AdventureUpdateDTO();
            updateDto.Name = existAdventure.Name;
            updateDto.IsDeleted = existAdventure.IsDeleted;
            updateDto.Description = existAdventure.Description;
            updateDto.StartDate = existAdventure.StartDate;
            updateDto.AdventureCategoryId = existAdventure.AdventureCategoryId;
            updateDto.Blocktext = existAdventure.Blocktext;

            return View(updateDto); 
        }

        [HttpPost]
        public IActionResult Update(AdventureUpdateDTO updateDto)
        {
            ViewBag.AdventureCategories = _adventureCategoryService.GetAllAdventureCategories(x => x.IsDeleted == false);

            if (!ModelState.IsValid)
                return View();

            try
            {
                _adventureService.UpdateAdventure(updateDto.Id, updateDto);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (ImageFileNotFoundException ex)
            {
                return NotFound();
            }
            catch (FileImageSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
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
                _adventureService.DeleteAdventure(id);
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
