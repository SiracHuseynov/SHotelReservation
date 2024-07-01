using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using SHotel.Business.DTOs.SliderDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;
using SHotel.Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Concretes
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public SliderService(ISliderRepository sliderRepository, IWebHostEnvironment env, IMapper mapper)
        {
            _sliderRepository = sliderRepository;
            _env = env;
            _mapper = mapper;
        }

        public async Task AddSlider(SliderCreateDTO sliderCreateDto)
        {
            if (sliderCreateDto.ImageFile == null)
                throw new ImageFileNotFoundException("Image olmalidir!");

            Slider slider = _mapper.Map<Slider>(sliderCreateDto); 

            slider.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\sliders", sliderCreateDto.ImageFile);

            await _sliderRepository.Add(slider);
            await _sliderRepository.CommitAsync();
        }

        public void DeleteSlider(int id)
        {
            var existSlider = _sliderRepository.Get(x => x.Id == id);

            if (existSlider == null)
                throw new EntityNotFoundException("Slider tapilmadi!");

            Helper.DeleteFile(_env.WebRootPath, @"uploads\sliders", existSlider.ImageUrl);

            _sliderRepository.Delete(existSlider);
            _sliderRepository.Commit();
        }

        public List<SliderGetDTO> GetAllSliders(Func<Slider, bool>? func = null)
        {
            var sliders = _sliderRepository.GetAll(func);

            List<SliderGetDTO> slidersDto = _mapper.Map<List<SliderGetDTO>>(sliders);
            return slidersDto;

        }

        public SliderGetDTO GetSlider(Func<Slider, bool>? func = null)
        {
            var slider = _sliderRepository.Get(func);
            SliderGetDTO sliderGetDTO = _mapper.Map<SliderGetDTO>(slider);  
            return sliderGetDTO;

        }

        public void Update(int id, SliderUpdateDTO sliderUpdateDto)
        {
            var existSlider = _sliderRepository.Get(x => x.Id == id);

            if (existSlider == null)
                throw new EntityNotFoundException("Slider tapilmadi!");

            if(sliderUpdateDto.ImageFile != null)
            {
                if (sliderUpdateDto.ImageFile.ContentType != "image/png")
                    throw new FileContentTypeException("File formati png ola biler!");

                Helper.DeleteFile(_env.WebRootPath, @"uploads\sliders", existSlider.ImageUrl);

                existSlider.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\sliders", sliderUpdateDto.ImageFile);

            }

            existSlider.IsDeleted = sliderUpdateDto.IsDeleted;
            existSlider.Title = sliderUpdateDto.Title;
            existSlider.Description = sliderUpdateDto.Description;
            existSlider.Icon = sliderUpdateDto.Icon;
            existSlider.RedirectText = sliderUpdateDto.RedirectText;

            _sliderRepository.Commit();
        }
    }
}
