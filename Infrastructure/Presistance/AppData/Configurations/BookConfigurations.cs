using Domain.Models.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.AppData.Configurations
{

    //public DateTime CreatedAt { get; set; }

    //public DateTime LastUpdatedAt { get; set; }
    internal class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.ISBN);

            builder.Property(b => b.ISBN)
                   .HasMaxLength(256);

            builder.Property(b => b.Title)
                  .HasMaxLength(256)
                  .IsRequired();

            builder.Property(b => b.Author)
                  .HasMaxLength(256)
                  .IsRequired();
            builder.Property(b => b.Edition)
                     .HasMaxLength(256)
                     .IsRequired();

            builder.Property(b => b.Description)
                    .HasMaxLength(700)
                    .IsRequired();

            builder.Property(b => b.PictureUrl)
                   .HasMaxLength(700)
                   .IsRequired();


            builder.Property(b => b.AvaliableQuantity)
                   .HasDefaultValue(0)
                   .IsRequired();

            builder.Property(b => b.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(b => b.LastUpdatedAt)
                   .HasComputedColumnSql("GETDATE()");

            /*  Book Category Configuration  */
            builder.HasOne(b => b.Category)
                   .WithMany(c => c.Books)
                   .HasForeignKey(b => b.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
