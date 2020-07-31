using System;
using System.Collections.Generic;
using System.Text;
using Library.Core.Models;

namespace Library.Core.Services
{
    public interface IBookService
    {
        Book Add(Book book);
        Book Get(int id);
        IEnumerable<Book> GetAll();

        IEnumerable<Book> GetBooksByAuthor(int authorId);

        IEnumerable<Book> GetBooksBySeries(int seriesId);
        void Remove(int id);
        Book Update(Book updatedBook);
    }
}
