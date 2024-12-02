using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UniqloProject.Models;

namespace UniqloProject.DAL
{
    public class AppDbContext:DbContext
    {
     
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<SliderItem> SliderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(e => e.Catagory)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.CatagoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
