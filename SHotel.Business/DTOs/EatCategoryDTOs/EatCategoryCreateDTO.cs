using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.EatCategoryDTOs
{
    public class EatCategoryCreateDTO
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }  
        
    }

    public class EatCategoryCreateDTOValidator : AbstractValidator<EatCategoryCreateDTO>
    {
        public EatCategoryCreateDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name bos ola bilmez!")
                .NotNull().WithMessage("Name null ola bilmez!")
                .MaximumLength(50).WithMessage("Name uzunlugu max 50 ola biler!");


        }
    }
}
