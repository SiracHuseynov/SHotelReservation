using SHotel.Business.DTOs.RoomDTOs;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Abstracts
{
    public interface IRoomService
    {
        Task AddAsyncRoom(RoomCreateDTO roomCreateDTO);
        void DeleteRoom(int id);
        void UpdateRoom(int id, RoomUpdateDTO roomUpdateDTO);
        RoomGetDTO GetRoom(Func<Room, bool>? func = null);
        List<RoomGetDTO> GetAllRooms(Func<Room, bool>? func = null);


    }
}
