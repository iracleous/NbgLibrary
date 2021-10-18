using NbgLibrary.Entities;
using NbgLibrary.Interfaces;
using NbgLibrary.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly IGenericReadRepository repository;

        public BookService(IGenericReadRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync(ISpecification<Book> specification = null)
        {
            var spec = new BookSpecification();
            return await repository.ListAsync(spec);
        }

        public async Task<Book> GetBookAsync(int index)
        {
            return await repository.GetByIdAsync<Book>(index);
        }
    }
}
