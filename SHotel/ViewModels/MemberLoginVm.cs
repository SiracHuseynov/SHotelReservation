using System.ComponentModel.DataAnnotations;

namespace SHotel.ViewModels
{
    public class MemberLoginVm
    {
        [Required]  
        public string UsernameOrEmail { get; set; } 
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }                


    }
}
