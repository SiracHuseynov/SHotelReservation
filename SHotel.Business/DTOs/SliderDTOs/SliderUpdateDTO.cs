using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.SliderDTOs
{
    public class SliderUpdateDTO
    {
        public int Id { get; set; }         
        public bool IsDeleted { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? Icon { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? RedirectText { get; set; }
    }

    public class SliderUpdateDTOValidator : AbstractValidator<SliderUpdateDTO>
    {
        public SliderUpdateDTOValidator()
        {

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Icon bos ola bilmez!")
                .NotNull().WithMessage("Icon null ola bilmez!")
                .MaximumLength(50).WithMessage("Icon uzunlugu 100 ola biler!");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Desciption bos ola bilmez!")
                .NotNull().WithMessage("Desciption null ola bilmez!")
                .MaximumLength(50).WithMessage("Desciption uzunlugu 100 ola biler!");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title bos ola bilmez!")
                .NotNull().WithMessage("Title null ola bilmez!")
                .MaximumLength(50).WithMessage("Title uzunlugu 50 ola biler!");

            RuleFor(x => x.RedirectText)
                .NotEmpty().WithMessage("RedirectText bos ola bilmez!")
                .NotNull().WithMessage("RedirectText null ola bilmez!")
                .MaximumLength(50).WithMessage("RedirectText uzunlugu50 ola biler!");

        }
    }
}
