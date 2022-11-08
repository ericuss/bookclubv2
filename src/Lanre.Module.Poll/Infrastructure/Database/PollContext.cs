using Lanre.Infrastructure.Contexts;
using Lanre.Module.Poll.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Lanre.Module.Poll.Infrastructure.Database
{
    public class PollContext : ContextCore<PollContext>
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public PollContext(DbContextOptions<PollContext> options, IOptions<SqlOptions> sqlOptions)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            : base(options, sqlOptions)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookOfVoteList> BooksOfVoteList { get; set; }

        public DbSet<VoteList> VoteLists { get; set; }

        public DbSet<Vote> Votes { get; set; }
    }
}
