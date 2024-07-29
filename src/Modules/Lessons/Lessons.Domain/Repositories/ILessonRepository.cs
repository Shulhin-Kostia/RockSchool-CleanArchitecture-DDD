using BuildingBlocks.Domain;
using Lessons.Domain.Aggregates.Lessons;

namespace Lessons.Domain.Repositories;

public interface ILessonRepository : IRepository<Lesson, LessonId>
{
}
