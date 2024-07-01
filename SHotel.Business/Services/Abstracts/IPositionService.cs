using SHotel.Business.DTOs.PositionDTOs;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Abstracts
{
    public interface IPositionService
    {
        Task AddAsyncPosition(PositionCreateDTO positionCreateDTO);
        void DeletePosition(int id);
        void UpdatePosition(int id, PositionUpdateDTO positionUpdateDTO);
        PositionGetDTO GetPosition(Func<Position, bool>? func = null);
        List<PositionGetDTO> GetAllPositions(Func<Position, bool>? func = null);        

    }
}
