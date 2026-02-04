using Microsoft.EntityFrameworkCore;
using Notes.Data;
using Notes.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//
//
//
// Add Controller, Clean architecture, describe crud`s logic in Services, create DTO class
//
//
//

List<Note> notes = new List<Note>();

app.MapPost("/note", (NoteRecord noteRecord) =>
{
    Note note = new Note(noteRecord.Title, noteRecord.Content);

    notes.Add(note);

    return Results.Ok(note);
});

app.MapGet(("/note/all"), () => Results.Ok(notes));

app.MapDelete(("/note/{id}"), (Guid id) =>
{
    notes.RemoveAll(note => note.Id == id);

    return Results.Ok();
});

app.MapControllers();

app.Run();
