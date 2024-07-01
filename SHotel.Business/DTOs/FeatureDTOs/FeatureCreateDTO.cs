using FluentValidation;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.FeatureDTOs
{
    public class FeatureCreateDTO
    {

        public string Icon { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }     

    }

    public class FeatureCreateDTOValidator : AbstractValidator<FeatureCreateDTO>
    {
        public FeatureCreateDTOValidator()
        {
            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Icon bos ola bilmez!")
                .NotNull().WithMessage("Icon null ola bilmez!")
                .MaximumLength(100).WithMessage("Icon olcusu max 100 ola biler!");

            RuleFor(x=> x.Description)
                  .NotEmpty().WithMessage("Description bos ola bilmez!")
                .NotNull().WithMessage("Description null ola bilmez!")
                .MaximumLength(100).WithMessage("Description olcusu max 100 ola biler!");


        }
    }
}
