using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHotel.Business.DTOs.FeatureDTOs;
using SHotel.Business.DTOs.GuestReviewDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;

namespace SHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class GuestReviewController : Controller
    {
        private readonly IGuestReviewService _guestReviewService;
        private readonly IMapper _mapper;
        public GuestReviewController(IGuestReviewService guestReviewService, IMapper mapper)
        {
            _guestReviewService = guestReviewService;
            _mapper = mapper;
        }

        //public IActionResult Archive()
        //{
        //    var datas = _guestReviewService.GetAllGuestReviews(x=> x.IsDeleted == true);
        //    return View(datas);
        //}

        public IActionResult Archive(int page = 1)
        {
            var datas = _guestReviewService.GetAllGuestReviews(x => x.IsDeleted == true);

            List<GuestReview> guestReviewDto = _mapper.Map<List<GuestReview>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)guestReviewDto.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<GuestReview>.Create(guestReviewDto, 2, page);

            return View(paginatedDatas);
        }

        //public IActionResult Index()
        //{
        //    var datas = _guestReviewService.GetAllGuestReviews(x => x.IsDeleted == false);
        //    return View(datas);
        //}

        public IActionResult Index(int page = 1) 
        {
            var datas = _guestReviewService.GetAllGuestReviews(x => x.IsDeleted == false);

            List<GuestReview> guestReviewDtos = _mapper.Map<List<GuestReview>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)guestReviewDtos.Count / 2))
            {
                return RedirectToAction("Index");
            }

            var paginatedDatas = PaginatedList<GuestReview>.Create(guestReviewDtos, 2, page);

            return View(paginatedDatas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GuestReviewCreateDTO guestReviewCreateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _guestReviewService.AddAsyncGuestReview(guestReviewCreateDTO);
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
            var existReview = _guestReviewService.GetGuestReview(x => x.Id == id);

            if (existReview == null)
                return NotFound();

            var updateDto = new GuestReviewUpdateDTO();

            updateDto.FullName = existReview.FullName;
            updateDto.Description = existReview.Description;
            updateDto.Address = existReview.Address;
            updateDto.IsDeleted = existReview.IsDeleted;


            return View(updateDto); 
        }

        [HttpPost]
        public IActionResult Update(GuestReviewUpdateDTO guestReviewUpdateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _guestReviewService.UpdateGuestReview(guestReviewUpdateDTO.Id, guestReviewUpdateDTO);
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
                _guestReviewService.DeleteGuestReview(id);
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
