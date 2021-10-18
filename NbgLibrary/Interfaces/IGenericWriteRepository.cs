using NbgLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgLibrary.Interfaces
{
    public interface IGenericWriteRepository
    {
        Task<T> InsertAsync<T>(T entity) where T : BaseEntity;
        Task<int> InsertAsync<T>(IEnumerable<T> entities) where T : BaseEntity;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity;

        Task<int> SaveAsyn();

        Task UpdateAsync<T>(T entity) where T : BaseEntity;
        Task DeleteAsync<T>(T entity) where T : BaseEntity;
    }
}
