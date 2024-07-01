using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.FeatureDTOs
{
    public class FeatureUpdateDTO
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class FeatureUpdateDTOValidator : AbstractValidator<FeatureUpdateDTO>
    {
        public FeatureUpdateDTOValidator()
        {
            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Icon bos ola bilmez!")
                .NotNull().WithMessage("Icon null ola bilmez!")
                .MaximumLength(100).WithMessage("Icon olcusu max 100 ola biler!");

            RuleFor(x => x.Description)
                  .NotEmpty().WithMessage("Description bos ola bilmez!")
                .NotNull().WithMessage("Description null ola bilmez!")
                .MaximumLength(100).WithMessage("Description olcusu max 100 ola biler!");


        }
    }
}
