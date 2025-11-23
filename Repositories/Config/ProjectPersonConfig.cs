using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIS.Models;
using System;

namespace PIS.Repositories.Config
{
    public class ProjectPersonConfig : IEntityTypeConfiguration<ProjectPerson>
    {
        public void Configure(EntityTypeBuilder<ProjectPerson> builder)
        {
            builder.HasData(
                // Project 1: Gezgin Akıllı Robot
                new ProjectPerson { Id = 1, ProjectId = 1, PersonId = 1, RoleId = 3, StartDate = new DateTime(2024, 1, 15) }, // Ayşe Yılmaz (Öğrenci) as Bursiyer
                new ProjectPerson { Id = 2, ProjectId = 1, PersonId = 2, RoleId = 1, StartDate = new DateTime(2024, 1, 1) },  // Can Demir (Akademisyen) as Danışman

                // Project 2: Yapay Zeka Destekli Tarım Sistemi
                new ProjectPerson { Id = 3, ProjectId = 2, PersonId = 4, RoleId = 2, StartDate = new DateTime(2024, 2, 1) },  // Berk Şahin (Araştırmacı) as Araştırmacı
                new ProjectPerson { Id = 4, ProjectId = 2, PersonId = 5, RoleId = 3, StartDate = new DateTime(2024, 3, 1) },  // Deniz Arslan (Öğrenci) as Bursiyer

                // Project 3: Akıllı Şehir Yönetim Çözümleri
                new ProjectPerson { Id = 5, ProjectId = 3, PersonId = 6, RoleId = 1, StartDate = new DateTime(2023, 12, 1) },// Mert Gül (Akademisyen) as Danışman
                new ProjectPerson { Id = 6, ProjectId = 3, PersonId = 8, RoleId = 2, StartDate = new DateTime(2024, 1, 10) },// Okan Yıldız (Araştırmacı) as Araştırmacı

                 // Project 4: Yenilenebilir Enerji Depolama
                new ProjectPerson { Id = 7, ProjectId = 4, PersonId = 10, RoleId = 1, StartDate = new DateTime(2024, 5, 20) }, // Emre Kara (Akademisyen) as Danışman
                new ProjectPerson { Id = 8, ProjectId = 4, PersonId = 9, RoleId = 3, StartDate = new DateTime(2024, 6, 1) }  // Selin Çelik (Öğrenci) as Bursiyer
            );
        }
    }
}
