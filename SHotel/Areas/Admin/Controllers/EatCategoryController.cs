using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHotel.Business.DTOs.EatCategoryDTOs;
using SHotel.Business.DTOs.WorkerDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;
using System.Collections.Generic;

namespace SHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class EatCategoryController : Controller
    {
        private readonly IEatCategoryService _eatCategoryService;
        private readonly IMapper _mapper;
        public EatCategoryController(IEatCategoryService eatCategoryService, IMapper mapper)
        {
            _eatCategoryService = eatCategoryService;
            _mapper = mapper;
        }

        //public IActionResult Archive() 
        //{
        //    var datas = _eatCategoryService.GetAllEatCategories(x => x.IsDeleted == true); 
        //    return View(datas);
        //}

        public IActionResult Archive(int page = 1)
        {
            var datas = _eatCategoryService.GetAllEatCategories(x => x.IsDeleted == true);

            List<EatCategory> categoriesDtos = _mapper.Map<List<EatCategory>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)categoriesDtos.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<EatCategory>.Create(categoriesDtos, 2, page);

            return View(paginatedDatas); 
        }



        //public IActionResult Index()
        //{
        //    var datas = _eatCategoryService.GetAllEatCategories(x=> x.IsDeleted == false);
        //    return View(datas);
        //}

        public IActionResult Index(int page = 1)
        {
            var datas = _eatCategoryService.GetAllEatCategories(x => x.IsDeleted == false);

            List<EatCategory> eatCategoriesDtos = _mapper.Map<List<EatCategory>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)eatCategoriesDtos.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<EatCategory>.Create(eatCategoriesDtos, 2, page);

            return View(paginatedDatas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EatCategoryCreateDTO eatCategoryCreateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _eatCategoryService.AddAsyncEatCategory(eatCategoryCreateDTO);
            }
            catch (DuplicateEatCategoryException ex)
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
            var existEatCategory = _eatCategoryService.GetEatCategory(x=> x.Id == id);  
            if (existEatCategory == null)
                return NotFound();


            var updateDto = new EatCategoryUpdateDTO();
            updateDto.Name = existEatCategory.Name;
            updateDto.IsDeleted = existEatCategory.IsDeleted;

            return View(updateDto);
        }

        [HttpPost]
        public IActionResult Update(EatCategoryUpdateDTO updateDTO)
        {
            if(!ModelState.IsValid)
                return View();

            try
            {
                _eatCategoryService.UpdateEatCategory(updateDTO.Id, updateDTO);
            }
            catch(EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (DuplicateEatCategoryException ex)
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

        public IActionResult Delete(int id)
        {
            try
            {
                _eatCategoryService.DeleteEatCategory(id);
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
