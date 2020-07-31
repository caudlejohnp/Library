using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core.Models;

namespace Library.ApiModels
{
    public static class AuthorMappingExtensions
    {
        public static AuthorModel ToApiModel(this Author author)
        {
            return new AuthorModel
            {
                Id = author.Id,
                FullName = author.FirstName + " " + author.LastName
            };
        }

        public static Author ToDomainModel(this AuthorModel authorModel)
        {
            return new Author
            {
                Id = authorModel.Id,
                FirstName = authorModel.FirstName,
                LastName = authorModel.LastName,
            };
        }

        public static IEnumerable<AuthorModel> ToApiModel(this IEnumerable<Author> authors)
        {
            return authors.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Author> ToDomainModel(this IEnumerable<AuthorModel> authorModels)
        {
            return authorModels.Select(a => a.ToDomainModel());
        }
    }
}
