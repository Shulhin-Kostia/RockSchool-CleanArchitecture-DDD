using Lessons.Application.Lessons;
using Lessons.Domain.Aggregates.Lessons;
using Lessons.Domain.Repositories;

namespace API.Lessons
{
    public static class LessonEndpoints
    {
        public static void MapLessonEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/lessons/{id}", (Guid id, ILessonRepository lessonRepository, IStudentRepository studentRepository, ITeacherRepository teacherRepository) =>
            {
                return new GetLessonQueryHandler(lessonRepository, studentRepository, teacherRepository)
                    .Handle(new GetLessonQuery(new LessonId(id)), new CancellationToken());
            });
        }
    }
}
