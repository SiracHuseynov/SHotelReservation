using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.FeatureDTOs
{
    public class FeatureGetDTO
    {
        public int Id { get; set; }     
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }     

    }
}
