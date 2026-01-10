using MarkdownNoteTakeApi.Models.DTOs;

namespace MarkdownNoteTakeApi.Services.Interfaces
{
    public interface INoteService
    {
        Task<IEnumerable<NoteReadDto>> GetAllNotesAsync();
        Task<NoteReadDto?> GetNoteByIdAsync(Guid id);
        Task<string?> GetRenderedHtmlAsync(Guid id);
        Task<NoteReadDto> CreateNoteAsync(NoteCreateDto dto);
        Task<NoteReadDto> UploadNoteAsync(IFormFile file);
        Task<GrammarCheckResponseDto> CheckGrammarAsync(string text);
    }
}
