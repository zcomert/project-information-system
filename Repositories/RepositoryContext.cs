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
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Title = "Gezgin", Budget = 750000 },
                new Project { Id = 2, Title = "Yapay Zeka Destekli Tarım", Budget = 1250000 },
                new Project { Id = 3, Title = "Akıllı Şehir Çözümleri", Budget = 3000000 }
            );
        }
    }
}