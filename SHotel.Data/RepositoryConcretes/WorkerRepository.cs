﻿using SHotel.Core.Models;
using SHotel.Core.RepositoryAbstracts;
using SHotel.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Data.RepositoryConcretes
{
    public class WorkerRepository : GenericRepository<Worker>, IWorkerRepository
    {
        public WorkerRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
