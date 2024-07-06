using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppResit.Models;
namespace WebAppResit.Data
{
    public class WebAppResitContext : IdentityDbContext
    {
        public WebAppResitContext(DbContextOptions<WebAppResitContext> options)
            : base(options)
        {
        }

        public DbSet<BookItem> BookItems { get; set; } = default!;
        public DbSet<CheckoutCustomer> CheckoutCustomers { get; set; } = default!;
        public DbSet<Basket> Baskets { get; set; } = default!;
        public DbSet<BasketItem> BasketItems { get; set; } = default!;
        public DbSet<OrderHistory> OrderHistories { get; set; } = default!;
        public DbSet<OrderItem> OrderItems { get; set;} = default!;
        
        
        [NotMapped] 
        public DbSet<CheckoutItem> CheckoutItems { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookItem>().ToTable("BookItem");
            modelBuilder.Entity<OrderItem>().HasKey(o => new { o.OrderNo, o.OrderID });
            modelBuilder.Entity<BasketItem>().HasKey(t => new { t.StockID, t.BasketID });
        }
        
    }
}