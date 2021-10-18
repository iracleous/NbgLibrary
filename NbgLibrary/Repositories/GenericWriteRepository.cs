using NbgLibrary.Data;
using NbgLibrary.Entities;
using NbgLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgLibrary.Repositories
{
    public class GenericWriteRepository : IGenericWriteRepository
    {
        private readonly LibraryDbContext _dbContext;

        public GenericWriteRepository(LibraryDbContext libraryDbContext)
        {
            _dbContext = libraryDbContext;
        }


        public async Task<T> InsertAsync<T>(T entity) where T : BaseEntity
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<int> InsertAsync<T>(IEnumerable<T> entities) where T : BaseEntity
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            return await _dbContext.SaveChangesAsync();
        }


        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<int> SaveAsyn()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync<T>(T entity) where T : BaseEntity
        {
            await _dbContext.SaveChangesAsync();
        }





    }
}
