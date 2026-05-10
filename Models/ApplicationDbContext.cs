using System.Collections.Generic;
using System.Data.Entity;

namespace LibrarySystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<BorrowRecord> BorrowRecords { get; set; }
    }
}