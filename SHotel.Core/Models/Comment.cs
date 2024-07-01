using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Core.Models
{
    public class Comment : BaseEntity
    {
        public int? AdventureId { get; set; }   
        public string FullName { get; set; }    
        [EmailAddress]
        public string Email { get; set; }
        [Required]      
        public string Content { get; set; }
        public string Subject { get; set; }
        public Adventure? Adventure { get; set; }
        public AppUser? User { get; set; }
        public string? UserId { get; set; }
        

    }
}
