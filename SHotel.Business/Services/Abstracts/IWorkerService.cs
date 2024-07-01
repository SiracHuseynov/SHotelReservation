using SHotel.Business.DTOs.WorkerDTOs;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Abstracts
{
    public interface IWorkerService
    {
        Task AddAsyncWorker(WorkerCreateDTO workerCreateDTO);
        void DeleteWorker(int id);
        void UpdateWorker(int id, WorkerUpdateDTO workerUpdateDTO);
        WorkerGetDTO GetWorker(Func<Worker, bool>? func = null);
        List<WorkerGetDTO> GetAllWorkers(Func<Worker, bool>? func = null);


    }
}
