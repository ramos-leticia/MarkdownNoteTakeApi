using Ganss.Xss;
using Markdig;
using MarkdownNoteTakeApi.Models;
using MarkdownNoteTakeApi.Models.DTOs;
using MarkdownNoteTakeApi.Repositories;
using MarkdownNoteTakeApi.Services.Interfaces;
using MarkdownNoteTakeApi.Services.RestEase;

namespace MarkdownNoteTakeApi.Services.Implementations
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _repository;
        private readonly ILanguageToolClient _languageToolClient;
        private readonly HtmlSanitizer _sanitizer;

        public NoteService(INoteRepository repository, ILanguageToolClient languageToolClient, HtmlSanitizer sanitizer)
        {
            _repository = repository;
            _languageToolClient = languageToolClient;
            _sanitizer = sanitizer;
        }

        public async Task<GrammarCheckResponseDto> CheckGrammarAsync(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new GrammarCheckResponseDto(false, new List<GrammarErrorDto>());

            var payload = new Dictionary<string, string>
        {
            { "text", text },
            { "language", "pt-BR" },
            // "enabledOnly", "false" // opcional
        };

            try
            {
                var response = await _languageToolClient.CheckGrammarAsync(payload);

                var errors = response.Matches.Select(m => new GrammarErrorDto(
                    Message: m.Message,
                    ShortMessage: m.ShortMessage,
                    Suggestion: m.Replacements.FirstOrDefault()?.Value ?? "",
                    Column: m.Offset
                )).ToList();

                return new GrammarCheckResponseDto(
                    HasErrors: errors.Any(),
                    Errors: errors
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when calling LanguageTool: {ex.Message}");
                return new GrammarCheckResponseDto(false, new List<GrammarErrorDto>());
            }
        }

        public async Task<NoteReadDto> CreateNoteAsync(NoteCreateDto dto)
        {
            var note = new Note
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                RawContent = dto.RawContent,
                CreatedAt = DateTime.UtcNow,
            };

            await _repository.AddAsync(note);
            await _repository.SaveChangesAsync();

            return new NoteReadDto(note.Id, note.Title, note.RawContent, note.CreatedAt);
        }

        public async Task<IEnumerable<NoteReadDto>> GetAllNotesAsync()
        {
            var notes = await _repository.GetAllAsync();
            return notes.Select(note => new NoteReadDto(note.Id, note.Title, note.RawContent, note.CreatedAt));
        }

        public async Task<NoteReadDto?> GetNoteByIdAsync(Guid id)
        {
            var note = await _repository.GetByIdAsync(id);
            return note is not null ? new NoteReadDto(note.Id, note.Title, note.RawContent, note.CreatedAt) : null;
        }

        public async Task<string?> GetRenderedHtmlAsync(Guid id)
        {
            var note = await _repository.GetByIdAsync(id);
            if (note == null) return null;

            string unsanitizedHtml = Markdown.ToHtml(note.RawContent);

            return _sanitizer.Sanitize(unsanitizedHtml);
        }

        public async Task<NoteReadDto> UploadNoteAsync(IFormFile file)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            var content = await reader.ReadToEndAsync();

            var note = new Note
            {
                Id = Guid.NewGuid(),
                Title = file.FileName,
                RawContent = content,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(note);
            await _repository.SaveChangesAsync();

            return new NoteReadDto(note.Id, note.Title, note.RawContent, note.CreatedAt);
        }
    }
}
