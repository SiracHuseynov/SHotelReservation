﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.ReservationDTOs
{
    public class ReservationCreateDTO
    {
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }          
    }

    public class ReservationCreateDTOValidator : AbstractValidator<ReservationCreateDTO>
    {
        public ReservationCreateDTOValidator()
        {
            RuleFor(x => x.RoomId)
                .NotEmpty().WithMessage("RoomId bos ola bilmez!")
                .NotNull().WithMessage("RoomId null ola bilmez!");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("StartDate bos ola bilmez!")
                .NotNull().WithMessage("StartDate null ola bilmez!");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("EndDate bos ola bilmez!") 
                .NotNull().WithMessage("EndDate null ola bilmez!");
        }
    }

}
