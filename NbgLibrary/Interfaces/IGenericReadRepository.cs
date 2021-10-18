using NbgLibrary.Entities;
using NbgLibrary.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgLibrary.Interfaces
{
    public interface IGenericReadRepository
    {

        Task<T> GetByIdAsync<T>(int id) where T : BaseEntity;
        Task<T> GetAsync<T>(ISpecification<T> spec = null) where T : BaseEntity;
        Task<IQueryable<T>> GetAll<T>(ISpecification<T> spec = null) where T : BaseEntity;
        Task<int> CountAsync<T>(ISpecification<T> spec = null) where T : BaseEntity;
        Task<bool> IfExistsAsync<T>(ISpecification<T> spec = null) where T : BaseEntity;
        Task<IReadOnlyList<T>> ListAsync<T>(ISpecification<T> spec = null) where T : BaseEntity;


    }
}
