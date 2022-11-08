namespace Lanre.Module.Poll.Domain;

public class Vote
{
    private Vote() { }

    public Guid VoteListId { get; internal set; }
    public string UserId { get; internal set; }

    public List<string> Voted { get; internal set; } = new List<string>();
    public List<string> Readed { get; internal set; } = new List<string>();
    public List<string> Blocked { get; internal set; } = new List<string>();

    public VoteList VoteList { get; internal set; }

    public Vote SetIds(Guid voteListId, string? userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new ArgumentException($"'{nameof(userId)}' cannot be null or whitespace.", nameof(userId));
        }
        if (Guid.Empty == voteListId)
        {
            throw new ArgumentException($"'{nameof(voteListId)}' cannot be null or whitespace.", nameof(voteListId));
        }
        VoteListId = voteListId;
        UserId = userId;

        return this;
    }

    public Vote SetVoted(List<string> bookIds)
    {
        bookIds.ForEach(bookId =>
        {
            if (string.IsNullOrWhiteSpace(bookId) || !Guid.TryParse(bookId, out var id) || id == Guid.Empty)
            {
                throw new ArgumentException($"'{nameof(Voted)}''{nameof(bookId)}' cannot be null or whitespace.", nameof(bookId));
            }
        });

        Voted = bookIds;

        return this;
    }

    public Vote SetReaded(List<string> bookIds)
    {
        bookIds.ForEach(bookId =>
        {
            if (string.IsNullOrWhiteSpace(bookId) || !Guid.TryParse(bookId, out var id) || id == Guid.Empty)
            {
                throw new ArgumentException($"'{nameof(Readed)}''{nameof(bookId)}' cannot be null or whitespace.", nameof(bookId));
            }
        });

        Readed = bookIds;

        return this;
    }

    public Vote SetBlocked(List<string> bookIds)
    {
        bookIds.ForEach(bookId =>
        {
            if (string.IsNullOrWhiteSpace(bookId) || !Guid.TryParse(bookId, out var id) || id == Guid.Empty)
            {
                throw new ArgumentException($"'{nameof(Blocked)}' '{nameof(bookId)}' cannot be null or whitespace.", nameof(bookId));
            }
        });

        Blocked = bookIds;

        return this;
    }

    public class Builder
    {
        private Guid votelistId;
        private string? userId;
        private List<string> voted = new();
        private List<string> readed = new();
        private List<string> blocked = new();

        public Builder SetIds(Guid votelistId, string? userId)
        {
            this.votelistId = votelistId;
            this.userId = userId;
            return this;
        }

        public Builder SetVoted(List<string> voted)
        {
            this.voted = voted;
            return this;
        }

        public Builder SetReaded(List<string> readed)
        {
            this.readed = readed;
            return this;
        }

        public Builder SetBlocked(List<string> blocked)
        {
            this.blocked = blocked;
            return this;
        }

        public Vote Build()
        {
            var entity = new Vote()
                        .SetIds(this.votelistId, this.userId)
                        .SetVoted(this.voted)
                        .SetReaded(this.readed)
                        .SetBlocked(this.blocked)
                            ;
            return entity;
        }
    }
}
