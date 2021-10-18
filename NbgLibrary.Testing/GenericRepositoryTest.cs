using NbgLibrary.Entities;
using NbgLibrary.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NbgLibrary.Testing
{
    public class GenericRepositoryTest
    {
        [Fact]
        public void SaveAsync_Book_RightRecord()
        {
            var helper = new TestHelper();

            // Repositories with InMemory Database
            var readRepo = helper.GetInMemoryReadRepository();
            var writeRepo = helper.GetInMemoryWriteRepository();

            // use Write Repository to add mock data
            writeRepo.AddAsync(new Book()
            {
                BookName = "Hamlet",
                Author = new Author() { FirstName = "William", LastName = "Shakespear" },
                Category = new Category() { CategoryName = "Drama" }
            });


            // Commit insert
            writeRepo.SaveAsyn().GetAwaiter();


            // use Specification in Read Repository and get data
            var result = readRepo.GetAsync(new
                BookSpecification()).Result;




            // Assert
            Assert.NotNull(result);
            Assert.Equal("Hamlet", result.BookName);
            Assert.Equal("William", result.Author.FirstName);
            Assert.Equal("Shakespear", result.Author.LastName);
            Assert.Equal("Drama", result.Category.CategoryName);
            Assert.Equal(1, result.Id);

        }



        [Fact]
        public void GetAll_Authors_Count()
        {
            var helper = new TestHelper();

            // Repositories with InMemory Database
            var readRepo = helper.GetInMemoryReadRepository();
            var writeRepo = helper.GetInMemoryWriteRepository();

            List<Author> authors = helper.GetMockAuthors().ToList();

            writeRepo.InsertAsync(authors).GetAwaiter();

            var result =   readRepo.ListAsync(new AuthorSpecification()).Result ;

            Assert.Equal(3, result.Count());

        }


        [Fact]
        public void GetAsync_Authors_Find()
        {
            var helper = new TestHelper();

            var readRepo = helper.GetInMemoryReadRepository();
            var writeRepo = helper.GetInMemoryWriteRepository();

            var authors = helper.GetMockAuthors();

            writeRepo.InsertAsync(authors).GetAwaiter();
            var result = readRepo.GetAsync(new AuthorSpecification("William")).Result;

            Assert.Equal("Shakespear", result.LastName);
        }


        [Fact]
        public void GetAsync_Book_Find()
        {
            var helper = new TestHelper();

            var readRepo = helper.GetInMemoryReadRepository();
            var writeRepo = helper.GetInMemoryWriteRepository();

            var books = helper.GetMockBooks();

            writeRepo.InsertAsync(books).GetAwaiter();
            var result = readRepo.GetByIdAsync<Book>(2).Result;

            Assert.Contains("Oliver", result.BookName);
        }


    }
}
