using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using SHotel.Business.DTOs.AdventureDTOs;
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
    public class AdventureService : IAdventureService
    {
        private readonly IAdventureRepository _adventureRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public AdventureService(IAdventureRepository adventureRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _adventureRepository = adventureRepository;
            _mapper = mapper;
            _env = env;
        }

        public async Task AddAsyncAdventure(AdventureCreateDTO adventureCreateDTO)
        {
            if (adventureCreateDTO.ImageFile == null)
                throw new ImageFileNotFoundException("Image olmalidir!");

            Adventure adventure = _mapper.Map<Adventure>(adventureCreateDTO);

            adventure.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\adventures", adventureCreateDTO.ImageFile);

            await _adventureRepository.Add(adventure);
            await _adventureRepository.CommitAsync();
        }

        public void DeleteAdventure(int id)
        {
            var existAdventure = _adventureRepository.Get(x=> x.Id == id);

            if (existAdventure == null)
                throw new EntityNotFoundException("Adventure tapilmadi!");

            Helper.DeleteFile(_env.WebRootPath, @"uploads\adventures", existAdventure.ImageUrl);

            _adventureRepository.Delete(existAdventure);
            _adventureRepository.Commit();
        }

        public AdventureGetDTO GetAdventure(Func<Adventure, bool>? func = null)
        {
            var adventure = _adventureRepository.Get(func, "AdventureCategory");

            AdventureGetDTO adventureGetDTO = _mapper.Map<AdventureGetDTO>(adventure);

            return adventureGetDTO; 
        }

        public List<AdventureGetDTO> GetAllAdventures(Func<Adventure, bool>? func = null)
        {
            var adventures = _adventureRepository.GetAll(func, "AdventureCategory");

            List<AdventureGetDTO> adventureDtos = _mapper.Map<List<AdventureGetDTO>>(adventures);   

            return adventureDtos;
        }

        public void UpdateAdventure(int id, AdventureUpdateDTO adventureUpdateDTO)
        {
            var oldAdventure = _adventureRepository.Get(x => x.Id == id);

            if (oldAdventure == null)
                throw new EntityNotFoundException("Adventure tapilmadi!");

            if(adventureUpdateDTO.ImageFile != null)
            {
                if (adventureUpdateDTO.ImageFile.ContentType != "image/png")
                    throw new FileContentTypeException("File png formatinda olmalidir!");

                Helper.DeleteFile(_env.WebRootPath, @"uploads\adventures", oldAdventure.ImageUrl);

                oldAdventure.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\adventures", adventureUpdateDTO.ImageFile);

            }

            oldAdventure.Name = adventureUpdateDTO.Name;
            oldAdventure.Description = adventureUpdateDTO.Description;
            oldAdventure.IsDeleted = adventureUpdateDTO.IsDeleted;
            oldAdventure.StartDate = adventureUpdateDTO.StartDate;
            oldAdventure.AdventureCategoryId = adventureUpdateDTO.AdventureCategoryId;
            oldAdventure.BlockText = adventureUpdateDTO.Blocktext;

            _adventureRepository.Commit();

        }


    }
}
