namespace MarkdownNoteTakeApi.Models.DTOs
{
    public record NoteReadDto(
        Guid Id,
        string Title,
        string RawContent,
        DateTime CreatedAt
    );
}
