using AutoMapper;
using SHotel.Business.DTOs.BedDTOs;
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
    public class BedService : IBedService
    {
        private readonly IBedRepository _bedRepository;
        private readonly IMapper _mapper;
        public BedService(IBedRepository bedRepository, IMapper mapper)
        {
            _bedRepository = bedRepository;
            _mapper = mapper;
        }

        public async Task AddAsyncBed(BedCreateDTO bedCreateDTO)
        {
            Bed bed = _mapper.Map<Bed>(bedCreateDTO);

            if (!_bedRepository.GetAll().Any(x => x.Name == bed.Name))
            {
                await _bedRepository.Add(bed);
                await _bedRepository.CommitAsync();
            }
            else
            {
                throw new DuplicateBedException("Bed adi eyni ola bilmez!");
            }

        }

        public void DeleteBed(int id)
        {
            var existBed = _bedRepository.Get(x => x.Id == id);

            if (existBed == null)
                throw new EntityNotFoundException("Bed movcud deyil!");

            _bedRepository.Delete(existBed);
            _bedRepository.Commit();
        }

        public List<BedGetDTO> GetAllBeds(Func<Bed, bool>? func = null)
        {
            var beds = _bedRepository.GetAll(func);
            List<BedGetDTO> bedDtos = _mapper.Map<List<BedGetDTO>>(beds);
            return bedDtos;

        }

        public BedGetDTO GetBed(Func<Bed, bool>? func = null)
        {
            var bed = _bedRepository.Get(func);
            BedGetDTO bedDto = _mapper.Map<BedGetDTO>(bed);
            return bedDto;
        }

        public void UpdateBed(int id, BedUpdateDTO bedUpdateDTO)
        {
            var oldBed = _bedRepository.Get(x => x.Id == id);

            if (oldBed == null)
                throw new EntityNotFoundException("Bed tapilmadi!");


            if (!_bedRepository.GetAll().Any(x => x.Name == bedUpdateDTO.Name && x.Id != id))
            {
                oldBed.Name = bedUpdateDTO.Name;
                oldBed.IsDeleted = bedUpdateDTO.IsDeleted;
                _bedRepository.Commit();
            }
            else
            {
                throw new DuplicateBedException("Bed adi eyni ola bilmez!");
            }

        }
    }
}
