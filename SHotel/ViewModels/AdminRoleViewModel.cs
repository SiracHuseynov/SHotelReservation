using Microsoft.AspNetCore.Identity;
using SHotel.Core.Models;

namespace SHotel.ViewModels
{
    public class AdminRoleViewModel
    {
        public List<IdentityRole> Roles { get; set; }

        public IList<string> UserRoles { get; set; }
        public AppUser User { get; set; }   
    }
}
