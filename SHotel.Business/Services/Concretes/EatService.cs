using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using SHotel.Business.DTOs.EatDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Extensions;
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
    public class EatService : IEatService
    {
        private readonly IEatRepository _eatRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public EatService(IEatRepository eatRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _eatRepository = eatRepository;
            _mapper = mapper;
            _env = env;
        }

        public async Task AddAsyncEat(EatCreateDTO eatCreateDTO)
        {
            if (eatCreateDTO.ImageFile == null)
                throw new ImageFileNotFoundException("Image olmalidir!");

            Eat eat = _mapper.Map<Eat>(eatCreateDTO);

            eat.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\eats", eatCreateDTO.ImageFile);

            await _eatRepository.Add(eat);
            await _eatRepository.CommitAsync();
        }

        public void DeleteEat(int id)
        {
            var existEat = _eatRepository.Get(x => x.Id == id);

            if (existEat == null)
                throw new EntityNotFoundException("Eat tapilmadi!");

            Helper.DeleteFile(_env.WebRootPath, @"uploads\eats", existEat.ImageUrl);    

            _eatRepository.Delete(existEat);
            _eatRepository.Commit();
        }

        public List<EatGetDTO> GetAllEats(Func<Eat, bool>? func = null)
        {
            var eats = _eatRepository.GetAll(func, "EatCategory");

            List<EatGetDTO> eatDtos = _mapper.Map<List<EatGetDTO>>(eats);

            return eatDtos;
        }

        public EatGetDTO GetEat(Func<Eat, bool>? func = null)
        {
            var eat = _eatRepository.Get(func, "EatCategory");

            EatGetDTO eatDto = _mapper.Map<EatGetDTO>(eat);

            return eatDto;
        }

        public void UpdateEat(int id, EatUpdateDTO eatUpdateDTO)
        {
            var oldEat = _eatRepository.Get(x => x.Id == id);

            if (oldEat == null)
                throw new EntityNotFoundException("Eat tapilmadi!");

            if(eatUpdateDTO.ImageFile != null)
            {
                if (eatUpdateDTO.ImageFile.ContentType != "image/png")
                    throw new FileContentTypeException("File png formatinda olmalidir!");

                Helper.DeleteFile(_env.WebRootPath, @"uploads\eats", oldEat.ImageUrl);

                oldEat.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\eats", eatUpdateDTO.ImageFile);

            }

            oldEat.Name = eatUpdateDTO.Name;
            oldEat.Description = eatUpdateDTO.Description;
            oldEat.Price = eatUpdateDTO.Price;
            oldEat.IsDeleted = eatUpdateDTO.IsDeleted;
            oldEat.EatCategoryId = eatUpdateDTO.EatCategoryId;

            _eatRepository.Commit();

        }
    }
}
