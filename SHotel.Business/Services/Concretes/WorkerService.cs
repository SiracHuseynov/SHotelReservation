using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using SHotel.Business.DTOs.WorkerDTOs;
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
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public WorkerService(IWorkerRepository workerRepository, IWebHostEnvironment env, IMapper mapper)
        {
            _workerRepository = workerRepository;
            _env = env;
            _mapper = mapper;
        }

        public async Task AddAsyncWorker(WorkerCreateDTO workerCreateDTO)
        {
            if (workerCreateDTO.ImageFile == null)
               throw new ImageFileNotFoundException("Image olmalidir!");

            Worker worker = _mapper.Map<Worker>(workerCreateDTO);

            worker.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\workers", workerCreateDTO.ImageFile);

            await _workerRepository.Add(worker);
            await _workerRepository.CommitAsync();
        }

        public void DeleteWorker(int id)
        {
            var existWorker = _workerRepository.Get(x=> x.Id == id);    
            
            if(existWorker == null)
                throw new EntityNotFoundException("Worker tapilmadi!");

            Helper.DeleteFile(_env.WebRootPath, @"uploads\workers", existWorker.ImageUrl);

            _workerRepository.Delete(existWorker);
            _workerRepository.Commit();
        }

        public List<WorkerGetDTO> GetAllWorkers(Func<Worker, bool>? func = null)
        {
            var workers = _workerRepository.GetAll(func, "Position"); 

            List<WorkerGetDTO> workersDtos = _mapper.Map<List<WorkerGetDTO>>(workers);  

            return workersDtos;
        }

        public WorkerGetDTO GetWorker(Func<Worker, bool>? func = null)
        {
            var worker = _workerRepository.Get(func, "Position");

            WorkerGetDTO workerDto = _mapper.Map<WorkerGetDTO>(worker);

            return workerDto;
        }

        public void UpdateWorker(int id, WorkerUpdateDTO workerUpdateDTO)
        {
            var oldWorker = _workerRepository.Get(x => x.Id == id);

            if (oldWorker == null)
                throw new EntityNotFoundException("Worker tapilmadi!");

            if(workerUpdateDTO.ImageFile != null)
            {
                if (workerUpdateDTO.ImageFile.ContentType != "image/png")
                    throw new FileContentTypeException("File png formatinda olmalidir!");

                Helper.DeleteFile(_env.WebRootPath, @"uploads\workers", oldWorker.ImageUrl);

                oldWorker.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\workers", workerUpdateDTO.ImageFile);

            }

            oldWorker.FullName = workerUpdateDTO.FullName;
            oldWorker.Description = workerUpdateDTO.Description;
            oldWorker.FbLink = workerUpdateDTO.FbLink;
            oldWorker.TwitterLink = workerUpdateDTO.TwitterLink;
            oldWorker.InstagramLink = workerUpdateDTO.InstagramLink;
            oldWorker.PositionId = workerUpdateDTO.PositionId;
            oldWorker.IsDeleted = workerUpdateDTO.IsDeleted;

            _workerRepository.Commit();


        }
    }
}
