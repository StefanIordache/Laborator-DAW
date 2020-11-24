using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DEMO_WebAPI_NET.Models;

namespace DEMO_WebAPI_NET.Contexts
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("LibraryConnectionString")
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}