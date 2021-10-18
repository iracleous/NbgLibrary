using NbgLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgLibrary.Specification
{
    public class AuthorSpecification:BaseSpecification<Author>
    {

        public AuthorSpecification() : base() { }
        public AuthorSpecification(string filter) :
            base(a => a.FirstName.Equals(filter) || a.LastName.Equals(filter))
        {

        }


    }
}
