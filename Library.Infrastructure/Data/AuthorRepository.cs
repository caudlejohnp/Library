using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Core.Models;
using Library.Core.Services;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Library.Infrastructure.Data
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _dbContext;

        public AuthorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Author Add(Author author)
        {
            _dbContext.Add(author);
            _dbContext.SaveChanges();
            return author;
        }

        public Author Get(int id)
        {
            return _dbContext.Authors
                .Include(b => b.Books)
                .Include(s => s.Series)
                .FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _dbContext.Authors
                .Include(b => b.Books)
                .Include(s => s.Series);
        }

        public void Remove(Author removeAuthor)
        {
            _dbContext.Remove(removeAuthor);
            _dbContext.SaveChanges();
        }

        public Author Update(Author updatedAuthor)
        {
            var currentAuthor = _dbContext.Authors.Find(updatedAuthor.Id);
            if (currentAuthor == null) return null;

            _dbContext.Entry(currentAuthor)
                .CurrentValues
                .SetValues(updatedAuthor);

            _dbContext.Authors.Update(currentAuthor);
            _dbContext.SaveChanges();
            return currentAuthor;
        }
    }
}
