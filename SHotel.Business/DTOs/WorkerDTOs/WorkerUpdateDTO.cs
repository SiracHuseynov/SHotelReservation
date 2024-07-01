using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.DTOs.WorkerDTOs
{
    public class WorkerUpdateDTO
    {
        public int Id { get; set; }      
        public string FullName { get; set; }
        public bool IsDeleted { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string Description { get; set; }
        public string? FbLink { get; set; }
        public string? TwitterLink { get; set; }
        public string? InstagramLink { get; set; }
        public int PositionId { get; set; }
    }

    public class WorkerUpdateDTOValidator : AbstractValidator<WorkerUpdateDTO>
    {
        public WorkerUpdateDTOValidator()
        {
            RuleFor(x => x.FullName)
                    .NotEmpty().WithMessage("Fullname bos ola bilmez!")
                    .NotNull().WithMessage("Fullname null ola bilmez!")
                    .MaximumLength(50).WithMessage("Fullname uzunlugu max 50 ola biler!");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description bos ola bilmez!")
                .NotNull().WithMessage("Description null ola bilmez!")
                .MaximumLength(150).WithMessage("Description uzunlugu max 150 ola biler!");

            RuleFor(x => x.FbLink)
                .MaximumLength(100).WithMessage("Fb link max uzunlugu 100 ola biler!");

            RuleFor(x => x.TwitterLink)
               .MaximumLength(100).WithMessage("Fb link max uzunlugu 100 ola biler!");

            RuleFor(x => x.InstagramLink)
               .MaximumLength(100).WithMessage("Fb link max uzunlugu 100 ola biler!");

            RuleFor(x => x.PositionId)
                .NotEmpty().WithMessage("PositionId bos ola bilmez!")
                .NotNull().WithMessage("PositionId null ola bilmez!");
        }
    }
}
