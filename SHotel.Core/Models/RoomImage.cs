using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Core.Models
{
    public class RoomImage : BaseEntity
    {
        public int RoomId { get; set; }      
        public string ImageUrl { get; set; }
        public bool IsPoster { get; set; }  //True olsa Poster, false olsa Detail sekiller  


        public Room Room { get; set; }


    }
}
