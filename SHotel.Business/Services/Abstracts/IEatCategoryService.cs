using SHotel.Business.DTOs.EatCategoryDTOs;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Abstracts
{
    public interface IEatCategoryService
    {
        Task AddAsyncEatCategory(EatCategoryCreateDTO eatCategoryCreateDTO);
        void DeleteEatCategory(int id);
        void UpdateEatCategory(int id, EatCategoryUpdateDTO eatCategoryUpdateDTO);
        EatCategoryGetDTO GetEatCategory(Func<EatCategory, bool>? func = null);
        List<EatCategoryGetDTO> GetAllEatCategories(Func<EatCategory, bool>? func = null);

    }
}
