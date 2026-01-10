using MarkdownNoteTakeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MarkdownNoteTakeApi.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Note> Notes => Set<Note>();
}
