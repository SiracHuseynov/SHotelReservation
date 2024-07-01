using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Core.Models
{
    public class Adventure : BaseEntity
    {
        public int AdventureCategoryId { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }  
        public DateTime StartDate { get; set; }
        public AdventureCategory AdventureCategory { get; set; }
        public List<Comment>? Comments { get; set; }
        public string BlockText { get; set; }           

    }
}

