using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Core.Models
{
    public class Reservation : BaseEntity
    {
        public int RoomId { get; set; }                                       
        public Room Room { get; set; }                               
        public DateTime? StartDate { get; set; }               
        public DateTime? EndDate { get; set; }                
        public AppUser User { get; set; }
        public string? UserId { get; set; }          


    }
}
