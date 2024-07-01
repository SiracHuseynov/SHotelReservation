using SHotel.Business.DTOs.FeatureDTOs;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Abstracts
{
    public interface IFeatureService
    {
        Task AddAsyncFeature(FeatureCreateDTO featureCreateDTO);  
        void DeleteFeature(int id);
        void UpdateFeature(int id, FeatureUpdateDTO featureUpdateDTO); 
        FeatureGetDTO GetFeature(Func<Feature, bool>? func = null);
        List<FeatureGetDTO> GetAllFeatures(Func<Feature, bool>? func = null);
    }
}
