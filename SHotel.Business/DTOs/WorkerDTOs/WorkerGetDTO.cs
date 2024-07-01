using Microsoft.AspNetCore.Http;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.WorkerDTOs
{
    public class WorkerGetDTO
    {
        public int Id { get; set; }         
        public string FullName { get; set; }
        public bool IsDeleted { get; set; }

        public string ImageUrl { get; set; }            
        public string Description { get; set; }
        public string? FbLink { get; set; } 
        public string? TwitterLink { get; set; } 
        public string? InstagramLink { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; } 

    }
}
