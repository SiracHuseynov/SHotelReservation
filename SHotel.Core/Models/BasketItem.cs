using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Core.Models
{
    public class BasketItem : BaseEntity
    {
        public string AppUserId { get; set; }
        public int RoomId { get; set; }
        public int DayCount { get; set; }
        public DateTime Arrive { get; set; }
        public DateTime Departure { get; set; }
        public Room Room { get; set; }
        public AppUser AppUser { get; set; }


    }
}
