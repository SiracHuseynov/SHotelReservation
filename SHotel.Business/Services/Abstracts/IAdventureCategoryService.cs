using SHotel.Business.DTOs.AdventureCategoryDTOs;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Abstracts
{
    public interface IAdventureCategoryService
    {
        Task AddAsyncAdventureCategory(AdventureCategoryCreateDTO adventureCategoryCreateDTO);
        void DeleteAdventureCategory(int id);
        void UpdateAdventureCategory(int id, AdventureCategoryUpdateDTO adventureCategoryUpdateDTO);
        AdventureCategoryGetDTO GetAdventureCategory(Func<AdventureCategory, bool>? func = null);
        List<AdventureCategoryGetDTO> GetAllAdventureCategories(Func<AdventureCategory, bool>? func = null);


    }
}
