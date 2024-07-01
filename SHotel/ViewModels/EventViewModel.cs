using SHotel.Business.DTOs.AdventureCategoryDTOs;
using SHotel.Business.DTOs.AdventureDTOs;
using SHotel.Business.Extensions;
using SHotel.Core.Models;

namespace SHotel.ViewModels
{
    public class EventViewModel
    {
        public List<AdventureGetDTO> Adventures = new List<AdventureGetDTO>();
        public List<AdventureCategoryGetDTO> AdventureCategories = new List<AdventureCategoryGetDTO>();     
        public AdventureGetDTO Adventure = new AdventureGetDTO();
        public PaginatedList<Adventure> PaginatedAdventures = new PaginatedList<Adventure>();
        public List<Comment> Comments = new List<Comment>();
        public Comment Comment = new Comment();

    }
}
