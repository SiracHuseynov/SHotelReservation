using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Core.Models
{
    public class OrderItem : BaseEntity
    {
        public int RoomId { get; set; }
        public int OrderId { get; set; }            
        public string RoomName { get; set; }
        public int DayCount { get; set; }
        public decimal? Price { get; set; }
        public int? DiscountPercent { get; set; }            
        public Room Room { get; set; }
        public Order Order { get; set; }            



    }
}
