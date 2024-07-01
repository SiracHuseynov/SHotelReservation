using AutoMapper;
using SHotel.Business.DTOs.PositionDTOs;
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
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;
        public PositionService(IPositionRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task AddAsyncPosition(PositionCreateDTO positionCreateDTO)
        {
            Position position = _mapper.Map<Position>(positionCreateDTO);

            if(!_positionRepository.GetAll().Any(x=> x.Name == position.Name))
            {
                await _positionRepository.Add(position);
                await _positionRepository.CommitAsync();
            }
            else
            {
                throw new DuplicatePositionException("Position adi eyni ola bilmez!");
            }
            
        }

        public void DeletePosition(int id)
        {
            var existPosition = _positionRepository.Get(x => x.Id == id);

            if (existPosition == null)
                throw new EntityNotFoundException("Position tapilmadi!");

            _positionRepository.Delete(existPosition);
            _positionRepository.Commit();
        }

        public List<PositionGetDTO> GetAllPositions(Func<Position, bool>? func = null)
        {
            var positions = _positionRepository.GetAll(func);

            List<PositionGetDTO> positionDtos = _mapper.Map<List<PositionGetDTO>>(positions);  
            
            return positionDtos;
        }

        public PositionGetDTO GetPosition(Func<Position, bool>? func = null)
        {
            var position = _positionRepository.Get(func);

            PositionGetDTO positionDto = _mapper.Map<PositionGetDTO>(position);

            return positionDto;
        }

        public void UpdatePosition(int id, PositionUpdateDTO positionUpdateDTO)
        {
            var existPosition = _positionRepository.Get(x=> x.Id == id);

            if (existPosition == null)
                throw new EntityNotFoundException("Position tapilmadi!");

            if(!_positionRepository.GetAll().Any(x=> x.Name == positionUpdateDTO.Name && x.Id != id))
            {
                existPosition.Name = positionUpdateDTO.Name;    
                existPosition.IsDeleted = positionUpdateDTO.IsDeleted;
                _positionRepository.Commit();
            }
            else
            {
                throw new DuplicatePositionException("Position adi eyni ola bilmez!");
            }

        }
    }
}
