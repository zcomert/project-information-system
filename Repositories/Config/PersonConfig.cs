using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIS.Models;

namespace PIS.Repositories.Config
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(
                new Person { Id = 1, FirstName = "Ayşe", LastName = "Yılmaz", StudentNumber = "S1001", StaffNumber = null, PersonType = "Öğrenci", IsActive = true },
                new Person { Id = 2, FirstName = "Can", LastName = "Demir", StudentNumber = null, StaffNumber = "E2001", PersonType = "Akademisyen", IsActive = true },
                new Person { Id = 3, FirstName = "Elif", LastName = "Kaya", StudentNumber = "S1002", StaffNumber = null, PersonType = "Öğrenci", IsActive = false },
                new Person { Id = 4, FirstName = "Berk", LastName = "Şahin", StudentNumber = null, StaffNumber = "E2002", PersonType = "Araştırmacı", IsActive = true },
                new Person { Id = 5, FirstName = "Deniz", LastName = "Arslan", StudentNumber = "S1003", StaffNumber = null, PersonType = "Öğrenci", IsActive = true },
                new Person { Id = 6, FirstName = "Mert", LastName = "Gül", StudentNumber = null, StaffNumber = "E2003", PersonType = "Akademisyen", IsActive = true },
                new Person { Id = 7, FirstName = "Zeynep", LastName = "Tekin", StudentNumber = "S1004", StaffNumber = null, PersonType = "Öğrenci", IsActive = false },
                new Person { Id = 8, FirstName = "Okan", LastName = "Yıldız", StudentNumber = null, StaffNumber = "E2004", PersonType = "Araştırmacı", IsActive = true },
                new Person { Id = 9, FirstName = "Selin", LastName = "Çelik", StudentNumber = "S1005", StaffNumber = null, PersonType = "Öğrenci", IsActive = true },
                new Person { Id = 10, FirstName = "Emre", LastName = "Kara", StudentNumber = null, StaffNumber = "E2005", PersonType = "Akademisyen", IsActive = true }
            );
        }
    }
}
