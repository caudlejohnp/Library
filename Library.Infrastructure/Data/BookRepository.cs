using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Core.Models;
using Library.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _dbContext;

        public BookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Book Add(Book book)
        {
            _dbContext.Add(book);
            _dbContext.SaveChanges();
            return book;
        }

        public Book Get(int id)
        {
            return _dbContext.Books
                .FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _dbContext.Books
                .Include(a => a.Author)
                .Include(s => s.Series);
        }

        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
            return _dbContext.Books
                .Include(a => a.Author)
                .Include(s => s.Series)
                .Where(b => b.AuthorId == authorId);
        }

        public IEnumerable<Book> GetBooksBySeries(int seriesId)
        {
            return _dbContext.Books
                .Include(a => a.Author)
                .Include(s => s.Series)
                .Where(s => s.SeriesId == seriesId);
        }

        public void Remove(Book removeBook)
        {
            _dbContext.Books.Remove(removeBook);
            _dbContext.SaveChanges();
        }

        public Book Update(Book updatedBook)
        {
            var currentBook = _dbContext.Books.Find(updatedBook.Id);
            if (currentBook == null) return null;

            _dbContext.Entry(currentBook)
                .CurrentValues
                .SetValues(updatedBook);

            _dbContext.Books.Update(currentBook);
            _dbContext.SaveChanges();
            return currentBook;
        }
    }
}
