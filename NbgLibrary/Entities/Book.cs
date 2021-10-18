using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgLibrary.Entities
{
    public class Book:BaseEntity
    {
        public string BookName { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int? AuthorId { get; set; }
        public virtual Author Author { get; set; }

    }
}
