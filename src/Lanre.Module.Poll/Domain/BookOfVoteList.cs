namespace Lanre.Module.Poll.Domain;

public class BookOfVoteList
{
    public Guid BookId { get; set; }

    public Guid VoteListId { get; set; }

    public Book Book { get; set; }

    public VoteList VoteList { get; set; }

    public List<string> Votes { get; set; } = new List<string>();

    public List<string> ReadedBy { get; set; } = new List<string>();

    public List<string> BloquedBy { get; set; } = new List<string>();
}    
