using BuildingBlocks.Domain;

namespace Lessons.Domain.Aggregates.Lessons;

public class LessonId(Guid value) : TypedIdValueBase(value);
