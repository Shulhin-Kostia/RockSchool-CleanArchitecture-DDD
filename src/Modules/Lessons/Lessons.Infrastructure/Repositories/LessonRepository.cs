using Lessons.Application;
using Lessons.Application.Lessons;
using Lessons.Domain.Aggregates.Lessons;
using Lessons.Domain.Repositories;
using Lessons.Infrastructure.Entities;

namespace Lessons.Infrastructure.Repositories;

public class LessonRepository(LessonsContext context) : BaseRepository<Lesson, LessonId>(context), ILessonRepository
{
}
