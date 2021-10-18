using Microsoft.EntityFrameworkCore;
using NbgLibrary.Data;
using NbgLibrary.Entities;
using NbgLibrary.Interfaces;
using NbgLibrary.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgLibrary.Repositories
{
    public class GenericReadRepository : IGenericReadRepository
    {
        private readonly LibraryDbContext dbContext;

        public GenericReadRepository(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CountAsync<T>(ISpecification<T> spec = null) where T : BaseEntity
        {
            return await ApplySpecification(spec).CountAsync<T>();
        }

        public  Task<IQueryable<T>> GetAll<T>(ISpecification<T> spec = null) where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync<T>(ISpecification<T> spec = null) where T : BaseEntity
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : BaseEntity
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> IfExistsAsync<T>(ISpecification<T> spec = null) where T : BaseEntity
        {
            return await ApplySpecification(spec).AnyAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync<T>(ISpecification<T> spec = null) where T : BaseEntity
        {
            return await dbContext.Set<T>().ToListAsync();
        }



        private IQueryable<T> ApplySpecification<T>(ISpecification<T> spec) where T : BaseEntity
        {
            return SpecificationEvaluator<T>.GetQuery(dbContext.Set<T>().AsQueryable(), spec);
        }




    }
}
