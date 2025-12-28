using MarkdownNoteTakeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkdownNoteTakeApi.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        public NoteController()
        {
            
        }

        [HttpGet()]
        public IActionResult GetNote()
        {
            // Lógica para obter a nota pelo ID
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetNoteById(Guid id)
        {
            // Lógica para obter a nota pelo ID
            return Ok();
        }

        [HttpGet("{id}/render")]
        public IActionResult RenderNote(Guid id)
        {
            // Lógica para renderizar a nota pelo ID
            return Ok();
        }

        [HttpPost("/grammar-check")]
        public IActionResult CheckNote([FromBody] Note note)
        {
            // Lógica para criar uma nova nota
            return CreatedAtAction(nameof(GetNoteById), new { id = note.Id }, note);
        }

        [HttpPost]
        public IActionResult CreateNote([FromBody] Note note)
        {
            // Lógica para criar uma nova nota
            return CreatedAtAction(nameof(GetNoteById), new { id = note.Id }, note);
        }
    }
}
