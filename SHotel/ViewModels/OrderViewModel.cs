using SHotel.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace SHotel.ViewModels
{
    public class OrderViewModel
    {

        //public List<CheckOutViewModel>? CheckOutViewModels { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
        public string? Note { get; set; }

    }
}
