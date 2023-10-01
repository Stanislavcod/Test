using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Model.DataBaseContext
{
    public class ApplicationDataBaseContext : DbContext
    {
        public ApplicationDataBaseContext(DbContextOptions<ApplicationDataBaseContext> options)
            :base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookLoan> BookLoans { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
            .Property(b => b.IsAvailable)
            .HasDefaultValue(true);
        }
    }
}
