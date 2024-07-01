using SHotel.Business.DTOs.FeatureDTOs;
using SHotel.Business.DTOs.GuestReviewDTOs;
using SHotel.Business.DTOs.RoomDTOs;
using SHotel.Business.DTOs.SliderDTOs;
using SHotel.Business.Extensions;
using SHotel.Core.Models;

namespace SHotel.ViewModels
{
    public class HomeViewModel
    {
        public List<SliderGetDTO> Sliders = new List<SliderGetDTO>();
        public List<FeatureGetDTO> Features  = new List<FeatureGetDTO>();
        public List<GuestReviewGetDTO> GuestReviews = new List<GuestReviewGetDTO>();
        public List<RoomGetDTO> Rooms = new List<RoomGetDTO>();
        public RoomGetDTO Room = new RoomGetDTO();
        public PaginatedList<Room> PaginatedRooms = new PaginatedList<Room>(); 

    }
}
