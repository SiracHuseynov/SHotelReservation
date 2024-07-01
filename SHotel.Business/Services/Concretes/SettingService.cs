using AutoMapper;
using SHotel.Business.DTOs.SettingDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;
using SHotel.Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Concretes
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;  
        public SettingService(ISettingRepository settingRepository, IMapper mapper)
        {
            _settingRepository = settingRepository;
            _mapper = mapper;
        }

        public async Task AddSettingAsync(SettingCreateDTO settingCreateDTO)
        {
            Setting setting = _mapper.Map<Setting>(settingCreateDTO);

            if(!_settingRepository.GetAll().Any(x=> x.Key == settingCreateDTO.Key))
            {
                await _settingRepository.Add(setting);
                await _settingRepository.CommitAsync();
            }
            else
            {
                throw new DuplicateKeyException("Key adi eyni ola bilmez!");  
            }
        }

        public void DeleteSetting(int id)
        {
            var existSetting = _settingRepository.Get(x=> x.Id == id);

            if (existSetting == null)
                throw new EntityNotFoundException("Setting tapilmadi!");

            _settingRepository.Delete(existSetting);
            _settingRepository.Commit();

        }

        public List<SettingGetDTO> GetAllSettings(Func<Setting, bool>? func = null)
        {
            var settings = _settingRepository.GetAll(func);

            List<SettingGetDTO> settingDtos = _mapper.Map<List<SettingGetDTO>>(settings);   

            return settingDtos;
        }

        public SettingGetDTO GetSetting(Func<Setting, bool>? func = null)
        {
            var setting = _settingRepository.Get(func);

            SettingGetDTO settingDto = _mapper.Map<SettingGetDTO>(setting);

            return settingDto;
        }

        public void UpdateSetting(int id, SettingUpdateDTO settingUpdateDTO)
        {
            var oldSetting = _settingRepository.Get(x => x.Id == id);

            if (oldSetting == null)
                throw new EntityNotFoundException("Setting tapilmadi!");

            if(!_settingRepository.GetAll().Any(x=> x.Key == settingUpdateDTO.Key && x.Id != id))
            {
                oldSetting.Key = settingUpdateDTO.Key;
                oldSetting.Value = settingUpdateDTO.Value;
                oldSetting.IsDeleted = settingUpdateDTO.IsDeleted; 
                _settingRepository.Commit();
            }
            else
            {
                throw new DuplicateKeyException("Key adi eyni ola bilmez!");
            }
        }


    }
}
