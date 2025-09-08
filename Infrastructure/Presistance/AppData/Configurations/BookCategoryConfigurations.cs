

using Domain.Models;
using Domain.Models.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;









namespace Presistance.AppData.Configurations
{
    internal class BookCategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CategoryName)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(c => c.Description)
                   .HasMaxLength(300)
                   .IsRequired();

            builder.Property(c => c.CategoryClassIcon)
                   .HasMaxLength(70)
                   .IsRequired();

            

        }
    }
}
