using Domain.Models.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Presistance.AppData.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .ToTable("Students");

            builder.Property(s => s.UniverstyId)
                   .HasMaxLength(100)
                   .IsRequired();

            builder
                .Property(s => s.IsVerified)
                .HasDefaultValue(false);
        }
    }
}
