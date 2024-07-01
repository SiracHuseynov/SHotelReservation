using SHotel.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace SHotel.ViewModels
{
    public class ForgetPasswordViewModel
    {
        public AppUser? appUser { get; set; }
        [DataType(DataType.Password)]       
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]   
        public string ConfirmPassword { get; set; }         


    }
}
