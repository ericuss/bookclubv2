namespace Lanre.Module.Poll.Domain;

public class VoteList
{
    private const int MaximumVotes = 10;

    public VoteList()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; internal set; }

    public string Name { get; internal set; }

    public int NumberOfVotes { get; internal set; }

    public string UserId { get; internal set; }

    public List<BookOfVoteList> Books { get; internal set; } = new List<BookOfVoteList>();

    public List<Vote> Votes { get; internal set; } = new List<Vote>();

    public VoteList SetName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
        }
        Name = name;
        return this;
    }
    public VoteList SetNumberOfVotes(int numberOfVotes)
    {
        if (numberOfVotes < 1 || numberOfVotes >= MaximumVotes)
        {
            throw new ArgumentException($"'{nameof(numberOfVotes)}' cannot be more than 9 and less than 1.", nameof(numberOfVotes));
        }
        NumberOfVotes = numberOfVotes;
        return this;
    }

    public VoteList SetUserId(string? userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new ArgumentException($"'{nameof(userId)}' cannot be null or whitespace.", nameof(userId));
        }
        UserId = userId;
        return this;
    }

    public VoteList SetBooks(List<string> bookIds)
    {
        bookIds.All(bookId =>
        {
            if (string.IsNullOrWhiteSpace(bookId)  || !Guid.TryParse(bookId, out var id) || id == Guid.Empty)
            {
                throw new ArgumentException($"'{nameof(bookId)}' cannot be null or whitespace.", nameof(bookId));
            }

            return true;
        });

        bookIds.ForEach(bookId => Books.Add(new BookOfVoteList { BookId = Guid.Parse(bookId) }));

        return this;
    }

    public class Builder
    {
        private string? name;
        private string? userId;
        private int numberOfVotes;
        private List<string> bookIds = new List<string>();

        public Builder SetName(string? name)
        {
            this.name = name;
            return this;
        }

        public Builder SetUserId(string? userId)
        {
            this.userId = userId;
            return this;
        }
        public Builder SetNumberOfVotes(int numberOfVotes)
        {
            this.numberOfVotes = numberOfVotes;
            return this;
        }
        public Builder SetBookIds(List<string> bookIds)
        {
            this.bookIds = bookIds;
            return this;
        }

        public VoteList Build()
        {
            var entity = new VoteList()
                            .SetName(this.name)
                            .SetUserId(this.userId)
                            .SetNumberOfVotes(this.numberOfVotes)
                            .SetBooks(this.bookIds)
                            ;
            return entity;
        }
    }
}
