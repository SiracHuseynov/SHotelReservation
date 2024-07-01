using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.GuestReviewDTOs
{
    public class GuestReviewGetDTO
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageUrl { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }


    }
}
