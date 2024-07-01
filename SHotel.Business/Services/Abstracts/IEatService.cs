using SHotel.Business.DTOs.EatDTOs;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Abstracts
{
    public interface IEatService
    {
        Task AddAsyncEat(EatCreateDTO eatCreateDTO);
        void DeleteEat(int id);
        void UpdateEat(int id, EatUpdateDTO eatUpdateDTO);
        EatGetDTO GetEat(Func<Eat, bool>? func = null);
        List<EatGetDTO> GetAllEats(Func<Eat, bool>? func = null);


    }
}
