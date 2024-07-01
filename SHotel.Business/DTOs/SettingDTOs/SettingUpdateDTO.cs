using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.SettingDTOs
{
    public class SettingUpdateDTO
    {
        public int Id { get; set; }
        public string Key { get; set; } 
        public string Value { get; set; }
        public bool IsDeleted { get; set; }

    }

    public class SettingUpdateDTOValidator : AbstractValidator<SettingUpdateDTO>
    {
        public SettingUpdateDTOValidator()
        {
            RuleFor(x => x.Key)
                .NotEmpty().WithMessage("Key bos ola bilmez!")
                .NotNull().WithMessage("Key null ola bilmez!");

            RuleFor(x => x.Value)
                .NotEmpty().WithMessage("Value bos ola bilmez!")
                .NotNull().WithMessage("Value null ola bilmez!");
        }
    }

}
