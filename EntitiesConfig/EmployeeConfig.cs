using Microsoft.EntityFrameworkCore;
using HR.Entities;

namespace HR.EntitiesConfig
{
    public class EmployeeConfig : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder
                .Property(p => p.Fname)
                .HasMaxLength(50);

            builder
              .Property(p => p.Lname)
              .HasMaxLength(50);

            //builder
            //  .HasKey(p => p.EmployeId);
        }
    }
}
