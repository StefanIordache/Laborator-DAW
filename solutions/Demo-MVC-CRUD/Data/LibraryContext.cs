using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Demo_MVC_CRUD.Models;

namespace Demo_MVC_CRUD.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("LibraryConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Author { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}