using API.Lessons;
using Lessons.Domain.Aggregates.Lessons;
using Lessons.Domain.Aggregates.Students;
using Lessons.Domain.Aggregates.Teachers;
using Lessons.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LessonsContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});

// Add services to the container.
builder.AddLessonServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

app.MapLessonEndpoints();

app.MapGet("/hi", () =>
{
    var teacher = Teacher.Create("Teacher1", []);
    var student = Student.Create("Student1");
    var lesson = Lesson.Create(student.Id, teacher.Id, DateTime.UtcNow, 60);

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<LessonsContext>();

        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();

        dbContext.Teachers.Add(teacher);
        dbContext.Students.Add(student);
        dbContext.Lessons.Add(lesson);

        dbContext.SaveChanges();
    }

    return Results.Ok(lesson.Id.Value);
});

app.Run();