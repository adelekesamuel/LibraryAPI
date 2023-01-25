using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Journal> Journals { get; set; }

    }
}
