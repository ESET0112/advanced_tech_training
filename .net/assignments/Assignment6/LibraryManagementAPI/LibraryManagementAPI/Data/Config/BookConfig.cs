using LibraryManagementAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementAPI.Data.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(x => x.BookId);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Genre).IsRequired();
            builder.Property(x => x.AuthorId).IsRequired();

            
            builder.HasOne<Author>()              // Book has one Author
            .WithMany()                       // Author has many Books (no navigation)
            .HasForeignKey(b => b.AuthorId)   // Use AuthorId as FK
            .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
