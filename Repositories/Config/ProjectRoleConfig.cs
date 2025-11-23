using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIS.Models;

namespace PIS.Repositories.Config
{
    public class ProjectRoleConfig : IEntityTypeConfiguration<ProjectRole>
    {
        public void Configure(EntityTypeBuilder<ProjectRole> builder)
        {
            builder.HasData(
                new ProjectRole { Id = 1, Name = "Danışman", Description = "Proje danışmanı" },
                new ProjectRole { Id = 2, Name = "Araştırmacı", Description = "Proje araştırmacısı" },
                new ProjectRole { Id = 3, Name = "Bursiyer", Description = "Proje bursiyeri" }
            );
        }
    }
}
