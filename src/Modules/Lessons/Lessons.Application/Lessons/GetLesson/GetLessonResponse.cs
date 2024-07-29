using Lessons.Domain.Aggregates.Students;
using Lessons.Domain.Aggregates.Teachers;

namespace Lessons.Application.Lessons;

public record GetLessonResponse(
    DateTime Date,
    Student Student,
    Teacher Teacher
);
