using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Library.Core.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public int SeriesId { get; set; }

        public Series Series { get; set; }
    }
}
