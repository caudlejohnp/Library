using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core.Models;

namespace Library.ApiModels
{
    public class SeriesModel
    {
        public int Id { get; set; }

        public string SeriesName { get; set; }

        public int SeriesNumber { get; set; }

        public int AuthorId { get; set; }

        public Author Authors { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
