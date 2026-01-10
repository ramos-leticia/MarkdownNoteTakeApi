using MarkdownNoteTakeApi.Data;
using MarkdownNoteTakeApi.Repositories;
using MarkdownNoteTakeApi.Services.Implementations;
using MarkdownNoteTakeApi.Services.Interfaces;
using MarkdownNoteTakeApi.Services.RestEase;
using Microsoft.EntityFrameworkCore;
using RestEase.HttpClientFactory;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));
var languageToolUrl = builder.Configuration.GetValue<string>("LanguageToolApi:BaseUrl");
builder.Services.AddRestEaseClient<ILanguageToolClient>(languageToolUrl)
    .ConfigureHttpClient(c =>
    {
        // Configurações opcionais de timeout, headers, etc.
        c.Timeout = TimeSpan.FromSeconds(10);
    });

builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<INoteService, NoteService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("API Markdown Note Take")
               .WithTheme(ScalarTheme.Solarized);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();