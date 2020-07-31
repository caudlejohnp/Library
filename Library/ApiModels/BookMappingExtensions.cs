using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core.Models;

namespace Library.ApiModels
{
    public static class BookMappingExtensions
    {
        public static BookModel ToApiModel(this Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                SeriesId = book.SeriesId,
                SeriesNumber = book.SeriesNumber
            };
        }

        public static Book ToDomainModel(this BookModel bookModel)
        {
            return new Book
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                AuthorId = bookModel.AuthorId,
                SeriesId = bookModel.SeriesId,
                SeriesNumber = bookModel.SeriesNumber
            };
        }

        public static IEnumerable<BookModel> ToApiModels(this IEnumerable<Book> books)
        {
            return books.Select(b => b.ToApiModel());
        }

        public static IEnumerable<Book> ToDomainModels(this IEnumerable<BookModel> bookModels)
        {
            return bookModels.Select(b => b.ToDomainModel());
        }
    }
}
