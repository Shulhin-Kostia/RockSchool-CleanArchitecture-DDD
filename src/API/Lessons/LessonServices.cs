using Lessons.Domain.Repositories;
using Lessons.Infrastructure.Repositories;

namespace API.Lessons
{
    public static class LessonServices
    {
        public static void AddLessonServices(this IHostApplicationBuilder builder)
        {
            builder.Services.AddScoped<ILessonRepository, LessonRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
        }
    }
}
