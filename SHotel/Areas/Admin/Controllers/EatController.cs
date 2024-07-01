using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHotel.Business.DTOs.EatDTOs;
using SHotel.Business.DTOs.FeatureDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;

namespace SHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class EatController : Controller
    {
        private readonly IEatService _eatService;
        private readonly IEatCategoryService _eatCategoryService;
        private readonly IMapper _mapper;
        public EatController(IEatService eatService, IEatCategoryService eatCategoryService, IMapper mapper)
        {
            _eatService = eatService;
            _eatCategoryService = eatCategoryService;
            _mapper = mapper;
        }

        //public IActionResult Archive()
        //{
        //    var datas = _eatService.GetAllEats(x => x.IsDeleted == true); 
        //    return View(datas);
        //}

        public IActionResult Archive(int page = 1)
        {
            ViewBag.EatCategories = _eatCategoryService.GetAllEatCategories(x => x.IsDeleted == false);

            var datas = _eatService.GetAllEats(x => x.IsDeleted == true);

            List<Eat> eatGetDtos = _mapper.Map<List<Eat>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)eatGetDtos.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Eat>.Create(eatGetDtos, 2, page);

            return View(paginatedDatas); 
        }

        //public IActionResult Index()
        //{
        //    var datas = _eatService.GetAllEats(x=> x.IsDeleted == false);
        //    return View(datas);
        //}

        public IActionResult Index(int page = 1)
        {
            ViewBag.EatCategories = _eatCategoryService.GetAllEatCategories(x => x.IsDeleted == false);

            var datas = _eatService.GetAllEats(x => x.IsDeleted == false);

            List<Eat> eatGetDtos = _mapper.Map<List<Eat>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)eatGetDtos.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Eat>.Create(eatGetDtos, 2, page);

            return View(paginatedDatas);
        }

        public IActionResult Create()
        {
            ViewBag.EatCategories = _eatCategoryService.GetAllEatCategories(x=> x.IsDeleted == false);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EatCreateDTO eatCreateDTO)
        {
            ViewBag.EatCategories = _eatCategoryService.GetAllEatCategories(x => x.IsDeleted == false);

            if (!ModelState.IsValid)
                return View();
             
            try
            {
                await _eatService.AddAsyncEat(eatCreateDTO);
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
            ViewBag.EatCategories = _eatCategoryService.GetAllEatCategories(x => x.IsDeleted == false);

            var existEat = _eatService.GetEat(x => x.Id == id);

            if (existEat == null)
                return NotFound();

            var updateDto = new EatUpdateDTO();
            updateDto.Name = existEat.Name; 
            updateDto.Description = existEat.Description;
            updateDto.Price = existEat.Price;
            updateDto.EatCategoryId = existEat.EatCategoryId;
            updateDto.IsDeleted = existEat.IsDeleted;



            return View(updateDto);
        }

        [HttpPost]
        public IActionResult Update(EatUpdateDTO eatUpdateDTO)
        {
            ViewBag.EatCategories = _eatCategoryService.GetAllEatCategories(x => x.IsDeleted == false);

            if (!ModelState.IsValid)
                return View();

            try
            {
                _eatService.UpdateEat(eatUpdateDTO.Id, eatUpdateDTO);
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
                _eatService.DeleteEat(id);
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
