using System;
using System.Collections.Generic;
using System.Text;
using Library.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder myBuilder)
        {
            myBuilder.UseSqlite("Data Source = ../Library.Infrastructure/Books.db");
        }
    }
}
