using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHotel.Business.DTOs.FeatureDTOs;
using SHotel.Business.DTOs.SliderDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Abstracts;
using SHotel.Business.Services.Concretes;
using SHotel.Core.Models;

namespace SHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;
        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        //public IActionResult Archive()
        //{
        //    var datas = _featureService.GetAllFeatures(x=> x.IsDeleted == true);
        //    return View(datas);
        //}

        public IActionResult Archive(int page = 1)
        {
            var datas = _featureService.GetAllFeatures(x => x.IsDeleted == true);

            List<Feature> featuresGetDto = _mapper.Map<List<Feature>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)featuresGetDto.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Feature>.Create(featuresGetDto, 2, page);

            return View(paginatedDatas); 
        }


        //public IActionResult Index()
        //{
        //    var datas = _featureService.GetAllFeatures(x=> x.IsDeleted == false);
        //    return View(datas); 
        //}

        public IActionResult Index(int page = 1) 
        {
            var datas = _featureService.GetAllFeatures(x => x.IsDeleted == false);

            List<Feature> featureGetDtos = _mapper.Map<List<Feature>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)featureGetDtos.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Feature>.Create(featureGetDtos, 2, page);

            return View(paginatedDatas); 
        }

        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create(FeatureCreateDTO featureCreate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _featureService.AddAsyncFeature(featureCreate);
            }


            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var existFeature = _featureService.GetFeature(x => x.Id == id);

            if (existFeature == null)
                return NotFound();

            var updateDto = new FeatureUpdateDTO();
            updateDto.Description = existFeature.Description;
            updateDto.Icon = existFeature.Icon;
            updateDto.IsDeleted = existFeature.IsDeleted;

            return View(updateDto);   
        }

        [HttpPost]
        public IActionResult Update(FeatureUpdateDTO featureUpdate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _featureService.UpdateFeature(featureUpdate.Id, featureUpdate);
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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                _featureService.DeleteFeature(id);
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
