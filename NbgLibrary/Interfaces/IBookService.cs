using NbgLibrary.Entities;
using NbgLibrary.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgLibrary.Interfaces
{
   public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(ISpecification<Book> specification = null);
        Task<Book> GetBookAsync(int index);
    }
}
