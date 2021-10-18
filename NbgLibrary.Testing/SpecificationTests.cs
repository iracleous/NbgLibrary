using NbgLibrary.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NbgLibrary.Testing
{
    public class SpecificationTests
    {
        [Fact]
        public void BookSpecTesting()
        {

            var helper = new TestHelper();
            var books = helper.GetMockBooks().AsQueryable();
            var spec = new BookSpecification("Twist");

            var result = books.FirstOrDefault(spec.Criteria);


            Assert.NotNull(result);
            Assert.Equal("Oliver Twist", result.BookName);
            Assert.Equal("Charles", result.Author.FirstName);
            Assert.Equal("Novel", result.Category.CategoryName);
        }


        [Fact]
        public void AuthorSpecTesting()
        {
            var helper = new TestHelper();
            var authors = helper.GetMockAuthors().AsQueryable();
            var spec = new AuthorSpecification("Charles");

            var result = authors.FirstOrDefault(spec.Criteria) ;


            Assert.Equal(2, result.Books.Count);
        }


    }
}
