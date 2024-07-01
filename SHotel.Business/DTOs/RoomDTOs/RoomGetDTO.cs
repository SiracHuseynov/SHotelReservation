using Microsoft.AspNetCore.Http;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.RoomDTOs
{
    public class RoomGetDTO
    {
        public int Id { get; set; }       
        public string Title { get; set; }   
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PersonCount { get; set; }
        public decimal Size { get; set; }
        public string View { get; set; }
        public bool IsAvailable { get; set; }
        public int BedId { get; set; }
        public bool IsDeleted { get; set; }
        public IFormFile? RoomPosterImageFile { get; set; }
        public List<IFormFile>? RoomDetailImageFiles { get; set; }
        public string RoomPosterImageUrl { get; set; }
        public RoomImage? RoomImage { get; set; }
        public List<RoomImage>? RoomImages { get; set; }
        public List<int>? RoomImageIds { get; set; }
        public Bed Bed { get; set; }
        public int? DiscountPercent { get; set; }
        public List<Reservation>? Reservations { get; set; }


    }
}
