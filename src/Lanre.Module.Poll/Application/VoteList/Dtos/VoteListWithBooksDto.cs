namespace Lanre.Module.Poll.Application.VoteList.Dtos;

public class VoteListWithBooksDto : VoteListDto
{
    public List<BookDto> Books { get; set; }
}
