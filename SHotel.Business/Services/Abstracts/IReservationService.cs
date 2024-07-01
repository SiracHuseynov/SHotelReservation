using SHotel.Business.DTOs.ReservationDTOs;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Abstracts
{
    public interface IReservationService
    {
        Task AddAsyncReservation(ReservationCreateDTO reservationCreateDTO);
        void DeleteReservation(int id);
        void UpdateReservation(int id, ReservationUpdateDTO reservationUpdateDTO);
        ReservationGetDTO GeTReservation(Func<Reservation, bool>? func = null);
        List<ReservationGetDTO> GetAllReservations(Func<Reservation, bool>? func = null);

    }
}
