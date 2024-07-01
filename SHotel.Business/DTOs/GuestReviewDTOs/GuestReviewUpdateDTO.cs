﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.GuestReviewDTOs
{
    public class GuestReviewUpdateDTO 
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? FullName { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }

    }

    public class GuestReviewUpdateDTOValidator : AbstractValidator<GuestReviewUpdateDTO>
    {
        public GuestReviewUpdateDTOValidator()
        {
            RuleFor(x => x.FullName)
                    .NotEmpty().WithMessage("FullName bos ola bilmez!")
                    .NotNull().WithMessage("FullName null ola bilmez!")
                    .MaximumLength(50).WithMessage("FullName uzunlugu max 50 ola biler!");


            RuleFor(x => x.Description)
                   .NotEmpty().WithMessage("Description bos ola bilmez!")
                   .NotNull().WithMessage("Description null ola bilmez!")
                   .MaximumLength(100).WithMessage("Description uzunlugu max 100 ola biler!");

            RuleFor(x => x.Address)
                  .NotEmpty().WithMessage("Address bos ola bilmez!")
                  .NotNull().WithMessage("Address null ola bilmez!")
                  .MaximumLength(100).WithMessage("Address uzunlugu max 100 ola biler!");

        }
    }
}
