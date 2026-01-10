namespace MarkdownNoteTakeApi.Models.DTOs
{
    public record GrammarErrorDto(
        string Message,
        string ShortMessage,
        string Suggestion,
        int Column
    );
}