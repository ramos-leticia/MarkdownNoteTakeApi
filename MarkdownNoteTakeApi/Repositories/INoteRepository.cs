using System;
using MarkdownNoteTakeApi.Models;

namespace MarkdownNoteTakeApi.Repositories;

public interface INoteRepository
{
  Task<Note?> GetByIdAsync(Guid id);
  Task<IEnumerable<Note>> GetAllAsync();
  Task AddAsync(Note note);
  Task UpdateAsync(Note note);
  Task DeleteAsync(Guid id);
  Task<bool> SaveChangesAsync();
}
