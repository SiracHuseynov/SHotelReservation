using SHotel.Core.Models;
using SHotel.Core.RepositoryAbstracts;
using SHotel.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Data.RepositoryConcretes
{
    public class AdventureCategoryRepository : GenericRepository<AdventureCategory>, IAdventureCategoryRepository
    {
        public AdventureCategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}

