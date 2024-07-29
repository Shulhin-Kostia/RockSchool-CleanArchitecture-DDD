using BuildingBlocks.Domain;

namespace Lessons.Domain.Aggregates.Students;

public class StudentId(Guid value) : TypedIdValueBase(value);
