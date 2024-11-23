using Microsoft.EntityFrameworkCore;
using RoughDraftInventoryManagmentSystem.Models;

namespace RoughDraftInventoryManagmentSystem.Data
{
    public class ApplicationDbContext   : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configure the Product entity if needed
            modelBuilder.Entity<Product>()
                .Property(p => p.ImageUrl);
        }

        public DbSet<Product> Products { get; set; }
    }
}
