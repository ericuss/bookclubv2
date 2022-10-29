namespace Lanre.Module.Poll.Infrastructure.Database.Mappings;

using Lanre.Module.Poll.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BookMapping : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books", "library", x => x.ExcludeFromMigrations());
    }
}

