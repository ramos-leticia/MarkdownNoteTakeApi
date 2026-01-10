using MarkdownNoteTakeApi.Data;
using MarkdownNoteTakeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MarkdownNoteTakeApi.Repositories;

public class NoteRepository : INoteRepository
{
  private readonly AppDbContext _context;

  public NoteRepository(AppDbContext context)
  {
    _context = context;
  }
  public async Task AddAsync(Note note)
         => await _context.Notes.AddAsync(note);

  public async Task DeleteAsync(Guid id)
  {
    var note = await GetByIdAsync(id);
    if (note != null) _context.Notes.Remove(note);
  }

  public async Task<IEnumerable<Note>> GetAllAsync()
        => await _context.Notes.ToListAsync();

  public async Task<Note?> GetByIdAsync(Guid id)
        => await _context.Notes.FindAsync(id);

  public async Task<bool> SaveChangesAsync()
        => (await _context.SaveChangesAsync()) > 0;

  public async Task UpdateAsync(Note note)
        => _context.Notes.Update(note);
}
