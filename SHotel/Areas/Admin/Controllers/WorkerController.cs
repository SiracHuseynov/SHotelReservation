using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHotel.Business.DTOs.PositionDTOs;
using SHotel.Business.DTOs.WorkerDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;

namespace SHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class WorkerController : Controller
    {
        private readonly IWorkerService _workerService;
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;
        public WorkerController(IWorkerService workerService, IPositionService positionService, IMapper mapper)
        {
            _workerService = workerService;
            _positionService = positionService;
            _mapper = mapper;
        }

        //public IActionResult Archive()  
        //{
        //    ViewBag.Positions = _positionService.GetAllPositions(x => x.IsDeleted == false);

        //    var datas = _workerService.GetAllWorkers(x => x.IsDeleted == true); 
        //    return View(datas);
        //}

        public IActionResult Archive(int page = 1)
        {
            ViewBag.Positions = _positionService.GetAllPositions(x => x.IsDeleted == false);

            var datas = _workerService.GetAllWorkers(x => x.IsDeleted == true);

            List<Worker> workerGetDtos = _mapper.Map<List<Worker>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)workerGetDtos.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Worker>.Create(workerGetDtos, 2, page);

            return View(paginatedDatas);
        }

        //public IActionResult Index()
        //{
        //    ViewBag.Positions = _positionService.GetAllPositions(x => x.IsDeleted == false);

        //    var datas = _workerService.GetAllWorkers(x=> x.IsDeleted == false);
        //    return View(datas);
        //}

        public IActionResult Index(int page = 1)
        {
            ViewBag.Positions = _positionService.GetAllPositions(x => x.IsDeleted == false);

            var datas = _workerService.GetAllWorkers(x => x.IsDeleted == false);

            List<Worker> workerGetDtos = _mapper.Map<List<Worker>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)workerGetDtos.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Worker>.Create(workerGetDtos, 2, page);

            return View(paginatedDatas);
        }

        public IActionResult Create()
        {
            ViewBag.Positions = _positionService.GetAllPositions(x=> x.IsDeleted == false);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkerCreateDTO workerCreateDTO)
        {
            ViewBag.Positions = _positionService.GetAllPositions(x => x.IsDeleted == false);

            if (!ModelState.IsValid)
                return View();

            try
            {
                await _workerService.AddAsyncWorker(workerCreateDTO);
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
            ViewBag.Positions = _positionService.GetAllPositions(x => x.IsDeleted == false);

            var existWorker = _workerService.GetWorker(x=> x.Id == id);
            if (existWorker == null)
                return NotFound();

            var updateDto = new WorkerUpdateDTO();

            updateDto.FullName = existWorker.FullName;
            updateDto.IsDeleted = existWorker.IsDeleted;
            updateDto.Description = existWorker.Description;
            updateDto.FbLink = existWorker.FbLink;
            updateDto.TwitterLink = existWorker.TwitterLink;
            updateDto.InstagramLink = existWorker.InstagramLink;
            updateDto.PositionId = existWorker.PositionId;


            return View(updateDto); 
        }

        [HttpPost]
        public IActionResult Update(WorkerUpdateDTO workerUpdateDTO)
        {
            ViewBag.Positions = _positionService.GetAllPositions(x => x.IsDeleted == false);

            if(!ModelState.IsValid)
                return View();

            try
            {
                _workerService.UpdateWorker(workerUpdateDTO.Id, workerUpdateDTO);
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
            ViewBag.Positions = _positionService.GetAllPositions(x => x.IsDeleted == false);

            try
            {
                _workerService.DeleteWorker(id);
            }
            catch(EntityNotFoundException ex)
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
