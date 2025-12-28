using System;

namespace MarkdownNoteTakeApi.Models;

public class Note
{
  public Guid Id { get; set; }
  public string Title { get; set; }
  public string RawContent { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
  public string FileExtension { get; set; }

}
