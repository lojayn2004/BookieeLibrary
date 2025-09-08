using Domain.Models.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Presistance.AppData.Configurations
{
    internal class BorrowBookConfiguration : IEntityTypeConfiguration<BorrowBookDetails>
    {
        public void Configure(EntityTypeBuilder<BorrowBookDetails> builder)
        {
            builder.HasKey(borrowBook => borrowBook.Id);

            builder.HasOne(sb => sb.Book)
                   .WithMany(b => b.Students)
                   .HasForeignKey(sb => sb.BookId);
            builder.Property(sb => sb.IsReturned)
                    .HasDefaultValue(false);

        }
    }
}
