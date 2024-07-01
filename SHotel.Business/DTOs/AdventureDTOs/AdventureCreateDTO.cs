using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.AdventureDTOs
{
    public class AdventureCreateDTO
    {
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile ImageFile { get; set; }
        
        public DateTime StartDate { get; set; }
        public int AdventureCategoryId { get; set; }
        public string Blocktext { get; set; }           

    }


    public class AdventureCreateDTOValidator : AbstractValidator<AdventureCreateDTO>
    {
        public AdventureCreateDTOValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Name bos ola bilmez")
             .NotNull().WithMessage("Name null ola bilmez!")
             .MaximumLength(50).WithMessage("Name uzunlugu max 50 ola biler!");


            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description bos ola bilmez")
                .NotNull().WithMessage("Description null ola bilmez!")
                .MaximumLength(500).WithMessage("Description uzunlugu max 500 ola biler!");

            RuleFor(x => x.ImageFile)
             .NotEmpty().WithMessage("Image bos ola bilmez");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("StartDate bos ola bilmez")
                .NotNull().WithMessage("StartDate null ola bilmez");

            RuleFor(x => x.AdventureCategoryId)
                .NotEmpty().WithMessage("AdventureCategoryId bos ola bilmez!")
                .NotNull().WithMessage("AdventureCategoryId null ola bilmez!");

            RuleFor(x => x.Blocktext)
              .NotEmpty().WithMessage("Blocktext bos ola bilmez")
              .NotNull().WithMessage("Blocktext null ola bilmez!")
              .MaximumLength(500).WithMessage("Blocktext uzunlugu max 500 ola biler!");


        }
    }
}
