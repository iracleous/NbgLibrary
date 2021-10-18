using NbgLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgLibrary.Specification
{
    public class BookSpecification:BaseSpecification<Book>
    {
        public BookSpecification() : base()
        {
            AddInclude(b => b.Author);
            AddInclude(b => b.Category);
        }
        public BookSpecification(string filter) :
            base(b => b.BookName.Contains(filter))
        {
            AddInclude(b => b.Author);
            AddInclude(b => b.Category);
        }
    }
}
