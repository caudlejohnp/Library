using System;
using System.Collections.Generic;
using System.Text;
using Library.Core.Models;

namespace Library.Core.Services
{
    public interface IBookRepository
    {
        //Create
        Book Add(Book book);

        //Read
        Book Get(int id);

        //Update
        Book Update(Book updatedBook);

        //Delete
        void Remove(Book removeBook);

        //List
        IEnumerable<Book> GetAll();

        IEnumerable<Book> GetBooksByAuthor(int authorId);

        IEnumerable<Book> GetBooksBySeries(int seriesId);
    }
}
