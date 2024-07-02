using Microsoft.EntityFrameworkCore;
using WebAppResit.Models;

namespace WebAppResit.Data
{
    public class WebAppResitContext : DbContext
    {
        public WebAppResitContext(DbContextOptions<WebAppResitContext> options)
            : base(options)
        {
        }
        
        public DbSet<BookItem> BookItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookItem>().ToTable("BookItem");
        }
    }
}