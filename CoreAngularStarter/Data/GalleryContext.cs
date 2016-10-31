using CoreAngularStarter.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreAngularStarter.Data
{
    public class GalleryContext : DbContext
    {
        public GalleryContext(DbContextOptions<GalleryContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryItem> CategoryItems { get; set; }
        public DbSet<CraftItem> CraftItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<CategoryItem>().ToTable("CategoryItem");
            modelBuilder.Entity<CraftItem>().ToTable("CraftItem");
        }
    }
}
