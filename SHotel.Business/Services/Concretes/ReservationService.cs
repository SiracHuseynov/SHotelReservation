using AutoMapper;
using SHotel.Business.DTOs.ReservationDTOs;
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
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task AddAsyncReservation(ReservationCreateDTO reservationCreateDTO)
        {
            Reservation reservation = _mapper.Map<Reservation>(reservationCreateDTO);

            await _reservationRepository.Add(reservation);
            await _reservationRepository.CommitAsync();
        }

        public void DeleteReservation(int id)
        {
            var existReservation = _reservationRepository.Get(x => x.Id == id);

            if (existReservation == null)
                throw new EntityNotFoundException("Reservation tapilmadi!");

            _reservationRepository.Delete(existReservation);
            _reservationRepository.Commit();
        }

        public List<ReservationGetDTO> GetAllReservations(Func<Reservation, bool>? func = null)
        {
            var reservations = _reservationRepository.GetAll(func, "Room"); 

            List<ReservationGetDTO> reservationDtos = _mapper.Map<List<ReservationGetDTO>>(reservations);

            return reservationDtos;
        }

        public ReservationGetDTO GeTReservation(Func<Reservation, bool>? func = null)
        {
            var reservation = _reservationRepository.Get(func, "Room"); 

            ReservationGetDTO reservationDto = _mapper.Map<ReservationGetDTO>(reservation);

            return reservationDto;
        }

        public void UpdateReservation(int id, ReservationUpdateDTO reservationUpdateDTO)
        {
            var oldReservation = _reservationRepository.Get(x => x.Id == id);

            if (oldReservation == null)
                throw new EntityNotFoundException("Reservation tapilmadi!");

            oldReservation.RoomId = reservationUpdateDTO.RoomId;
            oldReservation.StartDate = reservationUpdateDTO.StartDate;
            oldReservation.EndDate = reservationUpdateDTO.EndDate;
            oldReservation.IsDeleted = reservationUpdateDTO.IsDeleted;

            _reservationRepository.Commit();
        }
    }
}
