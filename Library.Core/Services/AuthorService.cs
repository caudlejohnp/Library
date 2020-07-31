using System;
using System.Collections.Generic;
using System.Text;
using Library.Core.Models;

namespace Library.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorService(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        public Author Add(Author newAuthor)
        {
            return _authorRepo.Add(newAuthor);
        }

        public Author Get(int id)
        {
            return _authorRepo.Get(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _authorRepo.GetAll();
        }

        public void Remove(int id)
        {
            var removeAuthor = _authorRepo.Get(id);
            _authorRepo.Remove(removeAuthor);
        }

        public Author Update(Author updatedAuthor)
        {
            return _authorRepo.Update(updatedAuthor);
        }
    }
}
