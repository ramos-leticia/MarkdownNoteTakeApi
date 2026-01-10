using Markdig;
using MarkdownNoteTakeApi.Models;
using MarkdownNoteTakeApi.Models.DTOs;
using MarkdownNoteTakeApi.Repositories;
using MarkdownNoteTakeApi.Services.Interfaces;

namespace MarkdownNoteTakeApi.Services.Implementations
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _repository;

        public NoteService(INoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<GrammarCheckResponseDto> CheckGrammarAsync(string text)
        {
            // TODO: Implementar chamada à API do LanguageTool
            // Por enquanto, retornamos um mock para testar o fluxo
            return await Task.FromResult(new GrammarCheckResponseDto(
                HasErrors: false,
                Errors: new List<GrammarErrorDto>()
            ));
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
            if (note is null) return null;

            return Markdown.ToHtml(note.RawContent);
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
