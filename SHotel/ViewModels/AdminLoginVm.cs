using System.ComponentModel.DataAnnotations;

namespace SHotel.ViewModels
{
    public class AdminLoginVm
    {
        [Required]
        public string Username { get; set; }
        [EmailAddress]
        public string? EmailAdress { get; set; } 
        [Required]
        [DataType(DataType.Password)] 
        [MinLength(8)]
        public string Password { get; set; }            

    }
}
