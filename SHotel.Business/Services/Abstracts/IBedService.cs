using SHotel.Business.DTOs.BedDTOs;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Abstracts
{
    public interface IBedService
    {
        Task AddAsyncBed(BedCreateDTO bedCreateDTO);
        void DeleteBed(int id);
        void UpdateBed(int id, BedUpdateDTO bedUpdateDTO);
        BedGetDTO GetBed(Func<Bed, bool>? func = null);
        List<BedGetDTO> GetAllBeds(Func<Bed, bool>? func = null);


    }
}
