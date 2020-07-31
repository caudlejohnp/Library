using System;
using System.Collections.Generic;
using System.Text;
using Library.Core.Models;

namespace Library.Core.Services
{
    public interface IAuthorService
    {
        Author Add(Author author);
        Author Get(int id);
        IEnumerable<Author> GetAll();
        void Remove(int id);
        Author Update(Author updatedAuthor);
    }
}
