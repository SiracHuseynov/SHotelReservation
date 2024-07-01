using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Core.Models
{
    public class Worker : BaseEntity
    {
        public int PositionId { get; set; }         
        public string FullName { get; set; }
        public Position? Position { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string? FbLink { get; set; }
        public string? TwitterLink { get; set; }
        public string? InstagramLink { get; set; }       
    }
}
