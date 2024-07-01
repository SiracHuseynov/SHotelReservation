using SHotel.Business.DTOs.RoomDTOs;

namespace SHotel.ViewModels
{
    public class CheckOutViewModel
    {
        public RoomGetDTO Room { get; set; }

        public int DayCount { get; set; }
        public DateTime ArriveDate { get; set; }
        public DateTime DepartureDate { get; set; }         

    }
}
