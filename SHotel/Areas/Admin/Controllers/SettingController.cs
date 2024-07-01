using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHotel.Business.DTOs.FeatureDTOs;
using SHotel.Business.DTOs.RoomDTOs;
using SHotel.Business.DTOs.SettingDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;

namespace SHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;
        private readonly IMapper _mapper;
        public SettingController(ISettingService settingService, IMapper mapper) 
        {
            _settingService = settingService;
            _mapper = mapper;
        }

        public IActionResult Archive(int page = 1)
        {
            var datas = _settingService.GetAllSettings(x => x.IsDeleted == true);

            List<Setting> settingGetDtos = _mapper.Map<List<Setting>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)settingGetDtos.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Setting>.Create(settingGetDtos, 2, page);  

            return View(paginatedDatas);
        }

        public IActionResult Index(int page = 1)
        {
            var datas = _settingService.GetAllSettings(x => x.IsDeleted == false);

            List<Setting> settingGetDtos = _mapper.Map<List<Setting>>(datas);

            if (page <= 0 || page > (double)Math.Ceiling((double)settingGetDtos.Count / 2))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<Setting>.Create(settingGetDtos, 2, page);

            return View(paginatedDatas);
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(SettingCreateDTO settingCreateDTO)
        //{
        //    if (!ModelState.IsValid)
        //        return View();

        //    try
        //    {
        //        await _settingService.AddSettingAsync(settingCreateDTO);
        //    }
        //    catch (DuplicateKeyException ex)
        //    {
        //        ModelState.AddModelError("Key", ex.Message);
        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //    return RedirectToAction("Index");
        //}

        public IActionResult Update(int id)
        {
            var existSetting = _settingService.GetSetting(x => x.Id == id);

            if (existSetting == null)
                return NotFound();

            var updateDto = new SettingUpdateDTO();
            updateDto.Key = existSetting.Key;
            updateDto.Value = existSetting.Value;
            updateDto.IsDeleted = existSetting.IsDeleted;  

            return View(updateDto);
        }

        [HttpPost]
        public IActionResult Update(SettingUpdateDTO settingUpdateDTO)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _settingService.UpdateSetting(settingUpdateDTO.Id, settingUpdateDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (DuplicateKeyException ex)
            {
                ModelState.AddModelError("Key", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        _settingService.DeleteSetting(id);
        //    }
        //    catch (EntityNotFoundException ex)
        //    {
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //    return Ok();

        //}


    }
}
