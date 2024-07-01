using AutoMapper;
using SHotel.Business.DTOs.AdventureCategoryDTOs;
using SHotel.Business.DTOs.EatCategoryDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;
using SHotel.Core.RepositoryAbstracts;
using SHotel.Data.RepositoryConcretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Concretes
{
    public class AdventureCategoryService : IAdventureCategoryService
    {
        private readonly IAdventureCategoryRepository _adventureCategoryRepository;
        private readonly IMapper _mapper;
        public AdventureCategoryService(IAdventureCategoryRepository adventureCategoryRepository, IMapper mapper)
        {
            _adventureCategoryRepository = adventureCategoryRepository;
            _mapper = mapper;
        }

        public async Task AddAsyncAdventureCategory(AdventureCategoryCreateDTO adventureCategoryCreateDTO)
        {
            AdventureCategory adventureCategory = _mapper.Map<AdventureCategory>(adventureCategoryCreateDTO);   

            if(!_adventureCategoryRepository.GetAll().Any(x=> x.Name == adventureCategory.Name))
            {
                await _adventureCategoryRepository.Add(adventureCategory);
                await _adventureCategoryRepository.CommitAsync();
            }
            else
            {
                throw new DuplicateAdventureCategoryException("Adventure Category adi eyni ola bilmez!");
            }

        }

        public void DeleteAdventureCategory(int id)
        {
            var existAdventureCategory = _adventureCategoryRepository.Get(x=> x.Id == id);

            if (existAdventureCategory == null)
                throw new EntityNotFoundException("Adventure Category adi tapilmadi!");

            _adventureCategoryRepository.Delete(existAdventureCategory);
            _adventureCategoryRepository.Commit();
        }

        public AdventureCategoryGetDTO GetAdventureCategory(Func<AdventureCategory, bool>? func = null)
        {
            var adventureCategory = _adventureCategoryRepository.Get(func);

            AdventureCategoryGetDTO adventureCategoryGetDTO = _mapper.Map<AdventureCategoryGetDTO>(adventureCategory);  

            return adventureCategoryGetDTO;
        }

        public List<AdventureCategoryGetDTO> GetAllAdventureCategories(Func<AdventureCategory, bool>? func = null)
        {
            var adventureCategories = _adventureCategoryRepository.GetAll(func);

            List<AdventureCategoryGetDTO> adventureCategoriesDtos = _mapper.Map<List<AdventureCategoryGetDTO>>(adventureCategories);

            return adventureCategoriesDtos;
        }


        public void UpdateAdventureCategory(int id, AdventureCategoryUpdateDTO adventureCategoryUpdateDTO)
        {
            var existAdventureCategory = _adventureCategoryRepository.Get(x => x.Id == id);

            if(existAdventureCategory == null)
                throw new EntityNotFoundException("Adventure Category tapilmadi!");

            if(!_adventureCategoryRepository.GetAll().Any(x => x.Name == adventureCategoryUpdateDTO.Name && x.Id != id))
            {
                existAdventureCategory.Name = adventureCategoryUpdateDTO.Name;
                existAdventureCategory.IsDeleted = adventureCategoryUpdateDTO.IsDeleted;
                _adventureCategoryRepository.Commit();
            }
            else
            {
                throw new DuplicateAdventureCategoryException("Adventure Category adi eyni ola bilmez!");
            }



        }
    }
}
