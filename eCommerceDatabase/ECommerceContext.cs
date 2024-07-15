using eCommerceDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Reflection.Metadata;

namespace eCommerceApi
{
    public class ECommerceContext : DbContext
    {
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> ProductCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ActiveSpecial> ActiveSpecials { get; set; }
        public DbSet<ProductOnSpecial> ProductOnSpecials { get; set; }
        public DbSet<BundleType> BundleTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        public ECommerceContext(DbContextOptions<ECommerceContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasAlternateKey(c => c.Name);
            modelBuilder.Entity<Brand>()
                .HasAlternateKey(b => b.Name);
            modelBuilder.Entity<Customer>()
                .HasAlternateKey(c => new { c.Username, c.Email, c.Phone });
            modelBuilder.Entity<Product>()
                .HasAlternateKey(p => new { p.Name, p.BrandId });
            modelBuilder.Entity<ProductOnSpecial>()
                .HasAlternateKey(p => new { p.ProductId, p.ActiveSpecialId });
            modelBuilder.Entity<BundleType>()
                .HasAlternateKey(p => p.Name);
            modelBuilder.Entity<ActiveSpecial>()
                .HasAlternateKey(p => new { p.Name, p.StartDate, p.EndDate });

            modelBuilder.Entity<Basket>()
                .HasMany(e => e.Items)
                .WithOne(e => e.Basket)
                .HasForeignKey(e => e.BasketId)
                .IsRequired();
            modelBuilder.Entity<BasketItem>()
                .HasOne(e => e.Basket);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.Items)
                .WithOne(e => e.Invoice)
                .HasForeignKey(e => e.InvoiceId)
                .IsRequired();
            modelBuilder.Entity<InvoiceItem>()
                .HasOne(e => e.Invoice);
        }
    }
}
