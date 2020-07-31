using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Library.Core.Models;

namespace Library.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;

        public BookService(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public Book Add(Book book)
        {
            _bookRepo.Add(book);
            return book;
        }

        public Book Get(int id)
        {
            return _bookRepo.Get(id);
        }

        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
            return _bookRepo.GetBooksByAuthor(authorId);
        }

        public IEnumerable<Book> GetBooksBySeries(int seriesId)
        {
            return _bookRepo.GetBooksBySeries(seriesId);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepo.GetAll();
        }

        public void Remove(int id)
        {
            var removeBook = _bookRepo.Get(id);
            _bookRepo.Remove(removeBook);
        }

        public Book Update(Book updatedBook)
        {
            var book = _bookRepo.Update(updatedBook);
            return book;
        }
    }
}
