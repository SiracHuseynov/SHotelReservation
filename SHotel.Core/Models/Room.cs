using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Core.Models
{
    public class Room : BaseEntity
    {
        public int BedId { get; set; }
        
        public string Title { get; set; }   
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PersonCount { get; set; }
        public decimal Size { get; set; }
        public string View { get; set; }
        public bool IsAvailable { get; set; }

        public Bed Bed { get; set; }

        public List<RoomImage>? RoomImages { get; set; }
        [NotMapped]   
        public List<int>? RoomImageIds { get; set; }
        public List<Reservation>? Reservations { get; set; }
        public int? DiscountPercent { get; set; }       


    }
}
