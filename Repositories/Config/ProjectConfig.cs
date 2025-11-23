using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIS.Models;

namespace PIS.Repositories.Config
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.Budget).HasColumnType("decimal(18, 2)");

            builder.HasData(
                new Project { Id = 1, Title = "Gezgin Akıllı Robot", Budget = 750000m },
                new Project { Id = 2, Title = "Yapay Zeka Destekli Tarım Sistemi", Budget = 1250000m },
                new Project { Id = 3, Title = "Akıllı Şehir Yönetim Çözümleri", Budget = 3000000m },
                new Project { Id = 4, Title = "Yenilenebilir Enerji Depolama", Budget = 2500000m },
                new Project { Id = 5, Title = "Eğitim Teknolojileri Platformu", Budget = 500000m },
                new Project { Id = 6, Title = "Gelişmiş Siber Güvenlik Sistemi", Budget = 1800000m },
                new Project { Id = 7, Title = "Biyomedikal Araştırma ve Geliştirme", Budget = 900000m },
                new Project { Id = 8, Title = "Mobil Sağlık Uygulaması", Budget = 350000m },
                new Project { Id = 9, Title = "Nesnelerin İnterneti (IoT) Çözümleri", Budget = 1100000m },
                new Project { Id = 10, Title = "Veri Analizi ve Görselleştirme Aracı", Budget = 600000m }
            );
        }
    }
}