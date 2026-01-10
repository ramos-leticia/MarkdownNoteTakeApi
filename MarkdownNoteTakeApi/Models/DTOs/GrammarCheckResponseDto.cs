namespace MarkdownNoteTakeApi.Models.DTOs
{
    public record GrammarCheckResponseDto(
        bool HasErrors,
        List<GrammarErrorDto> Errors
    );
}
