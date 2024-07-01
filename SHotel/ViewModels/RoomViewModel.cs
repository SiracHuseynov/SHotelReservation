using SHotel.Business.DTOs.ReservationDTOs;
using SHotel.Business.DTOs.RoomDTOs;
using SHotel.Business.Extensions;
using SHotel.Core.Models;

namespace SHotel.ViewModels
{
    public class RoomViewModel
    {
        public List<RoomGetDTO> Rooms = new List<RoomGetDTO>();  
        public List<ReservationGetDTO> Reservations = new List<ReservationGetDTO>();
        public RoomGetDTO Room = new RoomGetDTO();
        public PaginatedList<Room> PaginatedRooms = new PaginatedList<Room>();
        //public DateTime? ArriveDate { get; set; }  
        //public DateTime? DepartureTime { get; set; }
    }
}
