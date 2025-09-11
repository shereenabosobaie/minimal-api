using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1;
using WebApplication1.dbcontext;
using WebApplication1.models;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<Appdbcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/students", async (Appdbcontext db) =>
    await db.students.ToListAsync());

app.MapGet("/students/{id}", async (int id, Appdbcontext db) =>
    await db.students.FindAsync(id) is Student student
        ? Results.Ok(student)
        : Results.NotFound());

app.MapPost("/students", async (Student student, Appdbcontext db) =>
{
    db.students.Add(student);
    await db.SaveChangesAsync();
    return Results.Created($"/students/{student.id}", student);
});

app.MapPut("/students/{id}", async (int id, Student updatedStudent, Appdbcontext db) =>
{
    var student = await db.students.FindAsync(id);
    if (student is null) return Results.NotFound();

    student.name = updatedStudent.name;
    student.grade = updatedStudent.grade;
    student.subject = updatedStudent.subject;

    await db.SaveChangesAsync();
    return Results.Ok(student);
});

app.MapDelete("/students/{id}", async (int id, Appdbcontext db) =>
{
    var student = await db.students.FindAsync(id);
    if (student is null) return Results.NotFound();

    db.students.Remove(student);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
