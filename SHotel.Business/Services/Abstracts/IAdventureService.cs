using SHotel.Business.DTOs.AdventureDTOs;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Abstracts
{
    public interface IAdventureService
    {
        Task AddAsyncAdventure(AdventureCreateDTO adventureCreateDTO);
        void DeleteAdventure(int id);
        void UpdateAdventure(int id, AdventureUpdateDTO adventureUpdateDTO);
        AdventureGetDTO GetAdventure(Func<Adventure, bool>? func = null);
        List<AdventureGetDTO> GetAllAdventures(Func<Adventure, bool>? func = null);


    }
}
