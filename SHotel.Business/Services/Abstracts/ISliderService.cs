using SHotel.Business.DTOs.SliderDTOs;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Abstracts
{
    public interface ISliderService
    {
        Task AddSlider(SliderCreateDTO sliderCreateDto);
        void DeleteSlider(int id);
        void Update(int id, SliderUpdateDTO sliderUpdateDto);
        SliderGetDTO GetSlider(Func<Slider, bool>? func = null);
        List<SliderGetDTO> GetAllSliders(Func<Slider, bool>? func = null);


    }
}
