namespace Lanre.Module.Poll.Infrastructure.Database.Mappings;

using Lanre.Module.Poll.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BookOfVoteListMapping : IEntityTypeConfiguration<BookOfVoteList>
{
    public void Configure(EntityTypeBuilder<BookOfVoteList> builder)
    {
        builder.ToTable("BooksOfVoteList", "Poll");
        builder.HasKey(x => new { x.BookId, x.VoteListId });

        var valueComparer = new ValueComparer<List<string>>(
            (c1, c2) => (c1 ?? new List<string>()).SequenceEqual(c2 ?? new List<string>()),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());

        builder
            .Property(e => e.Votes)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList())
            .Metadata
            .SetValueComparer(valueComparer); 

        builder
            .Property(e => e.BloquedBy)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList())
            .Metadata
            .SetValueComparer(valueComparer);

        builder
            .Property(e => e.ReadedBy)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList())
            .Metadata
            .SetValueComparer(valueComparer);

        builder.HasOne(x => x.Book)
                .WithMany()
                .HasForeignKey(x => x.BookId)
                .IsRequired();

        builder.HasOne(x => x.VoteList)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.VoteListId)
                .IsRequired();

        Data(builder);
    }

    public static void Data(EntityTypeBuilder<BookOfVoteList> builder)
    {
        var book1 = new BookOfVoteList
        {
            BookId = Guid.Parse("8bddba00-f200-402d-b45b-6f1634a5f622"),
            VoteListId = Guid.Parse("8bddba00-f200-402d-b45b-6f1634a5f622"),
        };

        var book2 = new BookOfVoteList
        {
            BookId = Guid.Parse("8bddba00-f200-402d-b45b-6f1634a5f622"),
            VoteListId = Guid.Parse("332fb5ab-2eab-4393-a920-9b46faed3cb5"),
        };

        var book3 = new BookOfVoteList
        {
            BookId = Guid.Parse("332fb5ab-2eab-4393-a920-9b46faed3cb5"),
            VoteListId = Guid.Parse("332fb5ab-2eab-4393-a920-9b46faed3cb5"),
        };

        builder.HasData(
            book1,
            book2,
            book3
            );
    }
}

