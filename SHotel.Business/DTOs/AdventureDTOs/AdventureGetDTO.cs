using Microsoft.AspNetCore.Http;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.AdventureDTOs
{
    public class AdventureGetDTO
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string ImageUrl { get; set; }
        public string Blocktext { get; set; }

        public DateTime StartDate { get; set; }
        public int AdventureCategoryId { get; set; }
        public AdventureCategory AdventureCategory { get; set; }


    }
}
