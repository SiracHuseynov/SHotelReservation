using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Core.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }        
        public string Surname { get; set; }
        [NotMapped] 
        public List<Reservation>? Reservations { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<BasketItem>? BasketItems { get; set; }
        public List<Order> Orders { get; set; }             



    }
}
