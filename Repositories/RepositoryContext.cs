using Microsoft.EntityFrameworkCore;
using PIS.Models;

namespace PIS.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Yazılım Geliştirme" },
                new Category { CategoryId = 2, CategoryName = "Veri Bilimi" },
                new Category { CategoryId = 3, CategoryName = "Siber Güvenlik" }
            );  
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Title = "Gezgin", Budget = 750000, CategoryId = 1 },
                new Project { Id = 2, Title = "Yapay Zeka Destekli Tarım", Budget = 1250000, CategoryId = 2 },  
                new Project { Id = 3, Title = "Akıllı Şehir Çözümleri", Budget = 3000000, CategoryId = 1 }
            );
        }
    }
}