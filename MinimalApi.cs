using Microsoft.EntityFrameworkCore;
using WebApplication1.dbcontext;
using WebApplication1.models;

namespace WebApplication1
{
    public static class MinimalApi
    {
        public static void MapStudentEndpoints(this WebApplication app)
        {
            app.MapGet("/students", async (Appdbcontext db) =>
               await db.students.ToListAsync());

            app.MapGet("/students/{id}", async (int id, Appdbcontext db) =>
               await db.students.FindAsync(id) is Student student
                   ? Results.Ok(student)
                   : Results.NotFound());

            app.MapPost("/students", async ([Microsoft.AspNetCore.Mvc.FromBody]  Student student, Appdbcontext db) =>
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
                await db.SaveChangesAsync();

                return Results.NoContent();
            });
            app.MapDelete("/students/{id}", async (int id, Appdbcontext db) =>
            {
                var student = await db.students.FindAsync(id);
                if (student is null) return Results.NotFound();

                db.students.Remove(student);
                await db.SaveChangesAsync();

                return Results.Ok(student);
            });

        }
    }
}
