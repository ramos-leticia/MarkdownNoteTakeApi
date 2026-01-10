using System;

namespace MarkdownNoteTakeApi.Models;

public class Note
{
  public Guid Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string RawContent { get; set; } = string.Empty; // Conteúdo Markdown
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public string FileExtension { get; set; } = ".md";
}
