using Microsoft.AspNetCore.Http;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.EatDTOs
{
    public class EatGetDTO
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string ImageUrl { get; set; }        
        public int EatCategoryId { get; set; }
        public EatCategory EatCategory { get; set; }

    }
}
