using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.EatDTOs
{
    public class EatUpdateDTO
    {
        public int Id { get; set; }         
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile? ImageFile { get; set; }
        public int EatCategoryId { get; set; }
    }

    public class EatUpdateDTOValidator : AbstractValidator<EatUpdateDTO>
    {
        public EatUpdateDTOValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Eat bos ola bilmez")
             .NotNull().WithMessage("Eat null ola bilmez!")
             .MaximumLength(50).WithMessage("Eat uzunlugu max 50 ola biler!");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description bos ola bilmez")
                .NotNull().WithMessage("Description null ola bilmez!")
                .MaximumLength(150).WithMessage("Description uzunlugu max 150 ola biler!");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price bos ola bilmez")
                .NotNull().WithMessage("Price null ola bilmez!");
            

            RuleFor(x => x.EatCategoryId)
                .NotEmpty().WithMessage("EatCategoryId bos ola bilmez!")
                .NotNull().WithMessage("EatCategoryId null ola bilmez!");
        }
    }

}
