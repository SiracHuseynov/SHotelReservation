using AutoMapper;
using SHotel.Business.DTOs.FeatureDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;
using SHotel.Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Concretes
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;
        public FeatureService(IFeatureRepository featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }

        public async Task AddAsyncFeature(FeatureCreateDTO featureCreateDTO)
        {
            Feature feature = _mapper.Map<Feature>(featureCreateDTO);

            await _featureRepository.Add(feature);
            await _featureRepository.CommitAsync();
        }

        public void DeleteFeature(int id)
        {
            var existFeature = _featureRepository.Get(x => x.Id == id);

            if (existFeature == null)
                throw new EntityNotFoundException("Feature tapilmadi!");

            _featureRepository.Delete(existFeature);
            _featureRepository.Commit();
        }

        public List<FeatureGetDTO> GetAllFeatures(Func<Feature, bool>? func = null)
        {
            var features = _featureRepository.GetAll(func);

            List<FeatureGetDTO> featureGetDtos = _mapper.Map<List<FeatureGetDTO>>(features);  
            return featureGetDtos;
        }

        public FeatureGetDTO GetFeature(Func<Feature, bool>? func = null)
        {
            var feature = _featureRepository.Get(func);

            FeatureGetDTO featureDto = _mapper.Map<FeatureGetDTO>(feature);

            return featureDto;
        }

        public void UpdateFeature(int id, FeatureUpdateDTO featureUpdateDTO)
        {
            var existFeature = _featureRepository.Get(x=> x.Id == id);

            if (existFeature == null)
                throw new EntityNotFoundException("Feature tapilmadi!");

            existFeature.IsDeleted = featureUpdateDTO.IsDeleted;
            existFeature.Description = featureUpdateDTO.Description;
            existFeature.Icon = featureUpdateDTO.Icon;

            _featureRepository.Commit();

        }
    }
}
