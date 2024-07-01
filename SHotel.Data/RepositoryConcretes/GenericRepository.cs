using Microsoft.EntityFrameworkCore;
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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Add(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
        }

        public int Commit()
        {
            return _appDbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }

        public T Get(Func<T, bool>? func = null, params string[]? includes)
        {
            var entity = _appDbContext.Set<T>().AsQueryable();

            if(includes != null)
            {
                foreach (var item in includes)
                {
                    entity = entity.Include(item);
                }
            }

            return func == null ?
                entity.FirstOrDefault() :
                entity.FirstOrDefault(func);
        }

        public List<T> GetAll(Func<T, bool>? func = null, params string[]? includes)
        {
            var entity = _appDbContext.Set<T>().AsQueryable();

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    entity = entity.Include(item);
                }
            }

            return func == null ?
                entity.ToList() : 
                entity.Where(func).ToList();
        }


    }
}
