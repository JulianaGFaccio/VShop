using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //Fluent Api

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasKey(c => c.Id);

            mb.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();

            //Product
            mb.Entity<Product>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            mb.Entity<Product>().Property(p => p.Description).HasMaxLength(255).IsRequired();
            mb.Entity<Product>().Property(p => p.ImageUrl).HasMaxLength(255).IsRequired();
            mb.Entity<Product>().Property(p => p.Price).HasPrecision(10, 2).IsRequired();
            mb.Entity<Category>().HasMany(g => g.Products).WithOne(g => g.Category).IsRequired().OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Material Escolar"
                },
                new Category
                {
                    Id = 2,
                    Name = "Acessorios"
                });

        }

    }
}
