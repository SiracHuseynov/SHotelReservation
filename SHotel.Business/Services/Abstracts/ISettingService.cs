using SHotel.Business.DTOs.SettingDTOs;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Abstracts
{
    public interface ISettingService 
    {
        Task AddSettingAsync(SettingCreateDTO settingCreateDTO);
        void DeleteSetting(int id);
        void UpdateSetting(int id, SettingUpdateDTO settingUpdateDTO);  
        SettingGetDTO GetSetting(Func<Setting, bool>? func = null);
        List<SettingGetDTO> GetAllSettings(Func<Setting, bool>? func = null);


    }
}
