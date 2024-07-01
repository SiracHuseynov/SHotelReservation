using FluentValidation;
using Microsoft.AspNetCore.Http;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.RoomDTOs
{
    public class RoomCreateDTO 
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PersonCount { get; set; }
        public decimal Size { get; set; }
        public string View { get; set; }
        public bool IsAvailable { get; set; }
        public int BedId { get; set; }
        public bool IsDeleted { get; set; }
        public IFormFile RoomPosterImageFile { get; set; }
        public List<IFormFile> RoomDetailImageFiles { get; set; }
        public int? DiscountPercent { get; set; }            
    }

    public class RoomCreateDTOAbstract : AbstractValidator<RoomCreateDTO>
    {
        public RoomCreateDTOAbstract()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title bos ola bilmez!")
                .NotNull().WithMessage("Title null ola bilmez!")
                .MaximumLength(50).WithMessage("Title max olcusu 50 ola biler!");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description bos ola bilmez!")
                .NotNull().WithMessage("Description null ola bilmez!")
                .MaximumLength(150).WithMessage("Description max olcusu 150 ola biler!");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price bos ola bilmez!")
                .NotNull().WithMessage("Price null ola bilmez!");

            RuleFor(x => x.Size)
              .NotEmpty().WithMessage("Size bos ola bilmez!")
              .NotNull().WithMessage("Size null ola bilmez!");

            RuleFor(x => x.View)
                 .NotEmpty().WithMessage("View bos ola bilmez!")
                 .NotNull().WithMessage("View null ola bilmez!")
                 .MaximumLength(150).WithMessage("View max olcusu 50 ola biler!");

            RuleFor(x => x.RoomPosterImageFile)
               .NotEmpty().WithMessage("Image bos ola bilmez");

            RuleFor(x => x.RoomDetailImageFiles)
               .NotEmpty().WithMessage("Image bos ola bilmez");

            RuleFor(x => x.BedId)
                .NotEmpty().WithMessage("BedId bos ola bilmez!")
                .NotNull().WithMessage("BedId null ola bilmez!");

            RuleFor(x => x).Custom((x, context) =>
            {
                if(!(x.PersonCount >= 1 && x.PersonCount <= 4))
                {
                    context.AddFailure("Person sayi 1-den boyuk 4den kicik olmalidir!");
                }
            });


        }



    }

}
