namespace Lanre.Module.Library.Infrastructure.Database.Mappings;

using Lanre.Module.Library.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BookMapping : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books", "library");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(500).IsRequired();

        builder.HasIndex(x => x.Name).IsUnique();
        Data(builder);
    }

    public static void Data(EntityTypeBuilder<Book> builder)
    {
        var book1 = new Book.Builder()
                .SetAuthors("Brandon Sanderson")
                .SetUserId("0000000000")
                .SetImageUrl("https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1258916788l/7183286.jpg")
                .SetUrl("https://www.goodreads.com/book/show/7183286-el-imperio-final")
                .SetName("El imperio final")
                .SetSeries("Nacidos de la bruma")
                .SetSinopsis("")
                .SetPages("XXX")
                .SetRating("5")
                .Build();
        book1.Id = Guid.Parse("8bddba00-f200-402d-b45b-6f1634a5f622");

        var book2 = new Book.Builder()
                .SetAuthors("Orson Scott Card")
                .SetUserId("0000000000")
                .SetImageUrl("https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1408303130l/375802._SY475_.jpg")
                .SetUrl("https://www.goodreads.com/book/show/375802.Ender_s_Game")
                .SetName("El juego de Ender")
                .SetSeries("Ender")
                .SetSinopsis("")
                .SetPages("XXX")
                .SetRating("5")
                .Build();
        book2.Id = Guid.Parse("332fb5ab-2eab-4393-a920-9b46faed3cb5");

        builder.HasData(
            book1,
            book2
            );
    }
}

