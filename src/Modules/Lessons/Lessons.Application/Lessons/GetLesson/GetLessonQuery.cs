using BuildingBlocks.Application;
using Lessons.Domain.Aggregates.Lessons;

namespace Lessons.Application.Lessons;

public record class GetLessonQuery(LessonId LessonId) : IQuery<GetLessonResponse>;
