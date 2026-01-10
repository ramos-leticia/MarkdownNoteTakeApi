using System.ComponentModel.DataAnnotations;

namespace MarkdownNoteTakeApi.Models.DTOs
{
    public record NoteCreateDto(
        [Required(ErrorMessage = "The title is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The title must be between 3 and 100 characters.")]
        string Title,

        [Required(ErrorMessage = "Content cannot be empty.")]
        string RawContent
    );
}
