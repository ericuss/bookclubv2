namespace Lanre.Module.Poll.Application.VoteList.Dtos;

public class VoteDto
{
    public string Id { get; set; }
    public List<string> VotedIds { get; set; } = new List<string>();
    public List<string> ReadedIds { get; set; } = new List<string>();
    public List<string> BlockedIds { get; set; } = new List<string>();
}
