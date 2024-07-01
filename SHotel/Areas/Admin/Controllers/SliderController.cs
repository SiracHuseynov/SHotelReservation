using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHotel.Business.DTOs.RoomDTOs;
using SHotel.Business.DTOs.SliderDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;

namespace SHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;
        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        //public IActionResult Archive()
        //{
        //    var datas = _sliderService.GetAllSliders(x => x.IsDeleted == true);
        //    return View(datas);
        //}

        public IActionResult Archive(int page = 1)
        {
            var datas = _sliderService.GetAllSliders(x => x.IsDeleted == true);

            List<Slider> slidersGetDto = _mapper.Map<List<Slider>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)slidersGetDto.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Slider>.Create(slidersGetDto, 2, page);

            return View(paginatedDatas);
        }

        //public IActionResult Index()
        //{
        //    var datas = _sliderService.GetAllSliders(x=> x.IsDeleted == false); 
        //    return View(datas);
        //}

        public IActionResult Index(int page = 1)
        {
            var datas = _sliderService.GetAllSliders(x => x.IsDeleted == false);

            List<Slider> sliderGetDtos = _mapper.Map<List<Slider>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)sliderGetDtos.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Slider>.Create(sliderGetDtos, 2, page);

            return View(paginatedDatas); 
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateDTO sliderCreateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _sliderService.AddSlider(sliderCreateDTO);
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
            var existSlider = _sliderService.GetSlider(x => x.Id == id);

            var updateDto = new SliderUpdateDTO();

            if (existSlider == null)
                return NotFound();

            updateDto.Description = existSlider.Description;
            updateDto.Title = existSlider.Title;
            updateDto.RedirectText = existSlider.RedirectText;
            updateDto.Icon = existSlider.Icon;
            updateDto.IsDeleted = existSlider.IsDeleted;

            return View(updateDto);
        }

        [HttpPost]
        public IActionResult Update(SliderUpdateDTO sliderUpdateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _sliderService.Update(sliderUpdateDTO.Id, sliderUpdateDTO);
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
                _sliderService.DeleteSlider(id);
            }
            catch(EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (ImageFileNotFoundException ex)
            {
                return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }


            return Ok();

        }

    }
}
