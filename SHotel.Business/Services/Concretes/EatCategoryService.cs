using AutoMapper;
using SHotel.Business.DTOs.EatCategoryDTOs;
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
    public class EatCategoryService : IEatCategoryService
    {
        private readonly IEatCategoryRepository _eatCategoryRepository;
        private readonly IMapper _mapper;
        public EatCategoryService(IEatCategoryRepository eatCategoryRepository, IMapper mapper)
        {
            _eatCategoryRepository = eatCategoryRepository;
            _mapper = mapper;
        }

        public async Task AddAsyncEatCategory(EatCategoryCreateDTO eatCategoryCreateDTO)
        {
            EatCategory eatCategory = _mapper.Map<EatCategory>(eatCategoryCreateDTO);   

            if(!_eatCategoryRepository.GetAll().Any(x=> x.Name == eatCategory.Name))
            {
                await _eatCategoryRepository.Add(eatCategory);
                await _eatCategoryRepository.CommitAsync();
            }
            else
            {
                throw new DuplicateEatCategoryException("Eat Category adi eyni ola bilmez!"); 
            }

        }

        public void DeleteEatCategory(int id)
        {
            var existEatCategory = _eatCategoryRepository.Get(x => x.Id == id);

            if (existEatCategory == null)
                throw new EntityNotFoundException("Eat Category tapilmadi!");

            _eatCategoryRepository.Delete(existEatCategory);
            _eatCategoryRepository.Commit();

        }

        public List<EatCategoryGetDTO> GetAllEatCategories(Func<EatCategory, bool>? func = null)
        {
            var eatCategories = _eatCategoryRepository.GetAll(func);

            List<EatCategoryGetDTO> eatCategoryGetDTOs = _mapper.Map<List<EatCategoryGetDTO>>(eatCategories);
            
            return eatCategoryGetDTOs;
        }

        public EatCategoryGetDTO GetEatCategory(Func<EatCategory, bool>? func = null)
        {
            var eatCategory = _eatCategoryRepository.Get(func);

            EatCategoryGetDTO eatCategoryGetDto = _mapper.Map<EatCategoryGetDTO>(eatCategory);
            
            return eatCategoryGetDto;
        }

        public void UpdateEatCategory(int id, EatCategoryUpdateDTO eatCategoryUpdateDTO)
        {
            var existEatCategory = _eatCategoryRepository.Get(x => x.Id == id);

            if (existEatCategory == null)
                throw new EntityNotFoundException("Eat Category tapilmadi!");

            if(!_eatCategoryRepository.GetAll().Any(x=> x.Name == eatCategoryUpdateDTO.Name && x.Id != id))
            {
                existEatCategory.Name = eatCategoryUpdateDTO.Name;
                existEatCategory.IsDeleted = eatCategoryUpdateDTO.IsDeleted;
                _eatCategoryRepository.Commit();
            }
            else
            {
                throw new DuplicateEatCategoryException("Eat Category adi eyni ola bilmez!");
            }


        }
    }
}
