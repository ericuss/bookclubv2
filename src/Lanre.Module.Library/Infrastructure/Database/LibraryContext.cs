using Lanre.Module.Library.Domain;
using Lanre.Infrastructure.Contexts;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Lanre.Module.Library.Infrastructure.Database
{
    public class LibraryContext : ContextCore<LibraryContext>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options, IOptions<SqlOptions> sqlOptions) 
            : base(options, sqlOptions)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<MarkBook> MarkBooks { get; set; }
    }
}
