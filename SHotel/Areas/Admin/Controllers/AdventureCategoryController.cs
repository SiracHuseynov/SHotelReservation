using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHotel.Business.DTOs.AdventureCategoryDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Services.Abstracts;
using SHotel.Business.Services.Concretes;

namespace SHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdventureCategoryController : Controller
    {
        private readonly IAdventureCategoryService _adventureCategoryService;

        public AdventureCategoryController(IAdventureCategoryService adventureCategoryService)
        {
            _adventureCategoryService = adventureCategoryService;
        }

        public IActionResult Index()
        {
            var datas = _adventureCategoryService.GetAllAdventureCategories();
            return View(datas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdventureCategoryCreateDTO adventureCategoryCreateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _adventureCategoryService.AddAsyncAdventureCategory(adventureCategoryCreateDTO);
            }
            catch (DuplicateAdventureCategoryException ex)
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
            var existAdventureCategory = _adventureCategoryService.GetAdventureCategory(x=> x.Id == id);

            if (existAdventureCategory == null)
                return NotFound();

            var updateDto = new AdventureCategoryUpdateDTO();
            updateDto.Name = existAdventureCategory.Name;
            updateDto.IsDeleted = existAdventureCategory.IsDeleted;

            return View(updateDto);
        }


        [HttpPost]
        public IActionResult Update(AdventureCategoryUpdateDTO adventureCategoryUpdateDTO)
        {
            if(!ModelState.IsValid)
                return View();

            try
            {
                _adventureCategoryService.UpdateAdventureCategory(adventureCategoryUpdateDTO.Id, adventureCategoryUpdateDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (DuplicateAdventureCategoryException ex)
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
                _adventureCategoryService.DeleteAdventureCategory(id);
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
