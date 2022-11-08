namespace Lanre.Module.Poll.Infrastructure.Database.Mappings;

using Lanre.Module.Poll.Domain;
using Lanre.Module.Poll.Infrastructure.Comparers;
using Lanre.Module.Poll.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class VoteMapping : IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder.ToTable("Votes", "Poll");
        builder.HasKey(x => new { x.VoteListId, x.UserId });

        builder
            .Property(e => e.Voted)
            .HasConversion(
                StringConverters.StringListConverter.To,
                StringConverters.StringListConverter.From
            )
            .Metadata
            .SetValueComparer(StringComparers.StringListComparer);

        builder
            .Property(e => e.Readed)
            .HasConversion(
                StringConverters.StringListConverter.To,
                StringConverters.StringListConverter.From
            )
            .Metadata
            .SetValueComparer(StringComparers.StringListComparer);

        builder
            .Property(e => e.Blocked)
            .HasConversion(
                StringConverters.StringListConverter.To,
                StringConverters.StringListConverter.From
            )
            .Metadata
            .SetValueComparer(StringComparers.StringListComparer);


        builder.HasOne(x => x.VoteList)
                .WithMany(x => x.Votes)
                .HasForeignKey(x => x.VoteListId)
                .IsRequired();

        Data(builder);
    }

    public static void Data(EntityTypeBuilder<Vote> builder)
    {
    }
}

