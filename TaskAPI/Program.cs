using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using TaskAPI.Models;


var builder = WebApplication.CreateBuilder(args);

// Habilitar CORS sin restricciones para pruebas
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("https://localhost:4200") // URL del frontend
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials(); // Permitir cookies/sesiones si es necesario
    });
});

// Configurar Entity Framework Core con base de datos en memoria
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseInMemoryDatabase("TasksDb"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular"); // 💡 Asegurar que CORS se aplique ANTES de usar HTTPS

app.UseHttpsRedirection(); // 💡 Si la API usa HTTPS, Angular también debe usarlo

// Endpoints (Se mantienen igual)
app.MapGet("/tasks", async (TaskDbContext db) => await db.Tasks.ToListAsync()).WithName("GetTasks");
app.MapPost("/tasks", async (TaskDbContext db, TaskItem task) =>
{
    db.Tasks.Add(task);
    await db.SaveChangesAsync();
    return Results.Created($"/tasks/{task.Id}", task);
}).WithName("AddTask");
app.MapPut("/tasks/{id}", async (TaskDbContext db, int id, TaskItem updatedTask) =>
{
    var task = await db.Tasks.FindAsync(id);
    if (task == null) return Results.NotFound();
    task.Title = updatedTask.Title;
    task.Description = updatedTask.Description;
    task.Completed = updatedTask.Completed;
    await db.SaveChangesAsync();
    return Results.NoContent();
}).WithName("UpdateTask");
app.MapDelete("/tasks/{id}", async (TaskDbContext db, int id) =>
{
    var task = await db.Tasks.FindAsync(id);
    if (task == null) return Results.NotFound();
    db.Tasks.Remove(task);
    await db.SaveChangesAsync();
    return Results.NoContent();
}).WithName("DeleteTask");

app.Run();
