using System;
using System.Collections.Generic;
using System.Text;
using Library.Core.Models;

namespace Library.Core.Services
{
    public interface IAuthorRepository
    {
        //Create
        Author Add(Author author);

        //Read
        Author Get(int id);

        //Update
        Author Update(Author updatedAuthor);

        //Delete
        void Remove(Author author);

        //List
        IEnumerable<Author> GetAll();
    }
}
