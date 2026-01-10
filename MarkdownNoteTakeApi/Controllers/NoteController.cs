using MarkdownNoteTakeApi.Models;
using MarkdownNoteTakeApi.Models.DTOs;
using MarkdownNoteTakeApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkdownNoteTakeApi.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllNotes()
        {
            var notes = await _noteService.GetAllNotesAsync();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(Guid id)
        {
            var renderedHtml = await _noteService.GetRenderedHtmlAsync(id);
            if (renderedHtml is null)
            {
                return NotFound(new { Message = "Note not found." });
            }

            return Ok(renderedHtml);
        }

        [HttpGet("{id}/render")]
        public async Task<IActionResult> RenderNoteHtml(Guid id)
        {
            var htmlContent = await _noteService.GetRenderedHtmlAsync(id);

            if (htmlContent == null)
            {
                return NotFound(new { Message = "No note found to render." });
            }

            return Content(htmlContent, "text/html");
        }

        [HttpPost("grammar-check")]
        public async Task<IActionResult> CheckGrammar([FromBody] NoteCreateDto dto)
        {
            var result = await _noteService.CheckGrammarAsync(dto.RawContent);

            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateNote([FromBody] NoteCreateDto dto)
        {
            var createdNote = await _noteService.CreateNoteAsync(dto);

            return CreatedAtAction(nameof(GetNoteById), new { id = createdNote.Id }, createdNote);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadNote(IFormFile file)
        {
            if (file is null || file.Length == default)
            {
                return BadRequest(new { Message = "Please, send a valid markdown file (.md)." });
            }

            // Opcional: Validar extensão
            if (!file.FileName.EndsWith(".md", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest(new { Message = "Only .md files are allowed." });
            }

            var createdNote = await _noteService.UploadNoteAsync(file);

            return CreatedAtAction(nameof(GetNoteById), new { id = createdNote.Id }, createdNote);
        }
    }
}
