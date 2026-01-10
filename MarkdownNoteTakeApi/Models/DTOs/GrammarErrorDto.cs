namespace MarkdownNoteTakeApi.Models.DTOs
{
    public record GrammarErrorDto(
        string Message,
        string Suggestion,
        int Line,
        int Column
    );
}