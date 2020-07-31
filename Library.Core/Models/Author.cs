using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Book> Books { get; set; }

        public IEnumerable<Series> Series { get; set; }
    }
}
