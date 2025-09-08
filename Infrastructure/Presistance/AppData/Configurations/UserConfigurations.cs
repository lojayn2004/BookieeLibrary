using Domain.Models.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Presistance.AppData.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder
                .Property(u => u.UserName)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(u => u.Email)
                .HasMaxLength(200)
                .IsRequired();

        }
    }
}
