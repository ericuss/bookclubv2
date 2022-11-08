namespace Lanre.Module.Poll.Application.VoteList.Dtos;

public class CreateDto
{
    public string? Name { get; set; }

    public int NumberOfVotes { get; set; }

    public List<string> Books { get; set; } = new List<string>();
}
