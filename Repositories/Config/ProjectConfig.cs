using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIS.Models;

namespace PIS.Repositories.Config
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData(
                new Project { Id = 1, Title = "Gezgin", Budget = 750000 },
                new Project { Id = 2, Title = "Yapay Zeka Destekli Tarım", Budget = 1250000 },
                new Project { Id = 3, Title = "Akıllı Şehir Çözümleri", Budget = 3000000 }
            );
        }
    }
}
