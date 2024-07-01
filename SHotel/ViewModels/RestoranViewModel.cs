using SHotel.Business.DTOs.AdventureDTOs;
using SHotel.Business.DTOs.EatCategoryDTOs;
using SHotel.Business.DTOs.EatDTOs;
using SHotel.Core.Models;

namespace SHotel.ViewModels
{
    public class RestoranViewModel
    {
        public List<EatGetDTO> Eats = new List<EatGetDTO>(); 
        public List<EatCategoryGetDTO> EatCategories = new List<EatCategoryGetDTO>();
        public List<AdventureGetDTO> Adventures = new List<AdventureGetDTO>();   


    }
}
