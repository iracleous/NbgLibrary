using NbgLibrary.Entities;
using NbgLibrary.Specification;
using System;
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
            var readyRepo = helper.GetInMemoryReadRepository();
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
            var result = readyRepo.GetAsync(new
                BookSpecification()).Result;




            // Assert
            Assert.NotNull(result);
            Assert.Equal("Hamlet", result.BookName);
            Assert.Equal("William", result.Author.FirstName);
            Assert.Equal("Shakespear", result.Author.LastName);
            Assert.Equal("Drama", result.Category.CategoryName);
            Assert.Equal(1, result.Id);

        }
    }
}
