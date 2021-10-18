using Microsoft.EntityFrameworkCore;
using NbgLibrary.Data;
using NbgLibrary.Entities;
using NbgLibrary.Interfaces;
using NbgLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgLibrary.Testing
{
    public class TestHelper
    {

        private readonly LibraryDbContext libraryDbContext;

        public TestHelper()
        {
            var dbContextOptions = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: "LibraryDbInMemory")
                .Options;

            libraryDbContext = new LibraryDbContext(dbContextOptions);
            libraryDbContext.Database.EnsureDeleted();
            libraryDbContext.Database.EnsureCreated();
        }

        public IGenericReadRepository GetInMemoryReadRepository()
        {
            return new GenericReadRepository(libraryDbContext);
        }

        public IGenericWriteRepository GetInMemoryWriteRepository()
        {
            return new GenericWriteRepository(libraryDbContext);
        }



        public IEnumerable<Author> GetMockAuthors()
        {
            return new List<Author>()
            {
                { new Author(){ Id = 1, FirstName = "William", LastName = "Shakespear"} },
                { new Author(){ Id = 2, FirstName = "Charles", LastName = "Dickens"} },
                { new Author(){ Id = 3, FirstName = "George", LastName = "Eliot"} }
            };
        }


        public IEnumerable<Book> GetMockBooks()
        {
            return new List<Book>() {
                {new Book()
            {
                Id=1,
                BookName = "Hamlet",
                Author = new Author() { FirstName = "William", LastName = "Shakespear" },
                Category = new Category() { CategoryName = "Drama" }
            } },

                 {new Book()
            {
                Id=2,
                BookName = "Oliver Twist",
                Author = new Author() { FirstName = "Charles", LastName = "Dickens" },
                Category = new Category() { CategoryName = "Novel" }
            } },
                  {new Book()
            {
                Id=3,
                BookName = "Bleak House",
                Author = new Author() { FirstName = "Charles", LastName = "Dickens" },
                Category = new Category() { CategoryName = "Novel" }
            } }
            };
        }



    }
}
