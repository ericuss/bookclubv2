namespace Lanre.Module.Poll.Application.VoteList.Dtos;

public class VoteListDto
{
    public Guid? Id { get; set; }
    
    public string? Name { get; set; }

    public int NumberOfVotes { get; set; }

    public int NumberOfBooks { get; set; }

    public string? UserId { get; set; }

    public DateTimeOffset Created { get; set; }
}
