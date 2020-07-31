using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Models
{
    public class Series
    {
        public int Id { get; set; }

        public string SeriesName { get; set; }

        public int AuthorId { get; set; }

        public Author Authors { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
