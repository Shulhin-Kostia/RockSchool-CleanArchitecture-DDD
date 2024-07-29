using BuildingBlocks.Application.Abstractions.Messaging;
using Lessons.Domain.Repositories;

namespace Lessons.Application.Lessons;

public class GetLessonQueryHandler(
    ILessonRepository lessonRepository,
    IStudentRepository studentRepository,
    ITeacherRepository teacherRepository
) : IQueryHandler<GetLessonQuery, GetLessonResponse>
{
    public async Task<GetLessonResponse> Handle(GetLessonQuery request, CancellationToken cancellationToken)
    {
        var lesson = await lessonRepository.GetById(request.LessonId);
        if (lesson is null)
            throw new NotImplementedException();

        var student = await studentRepository.GetById(lesson.StudentId);
        var teacher = await teacherRepository.GetById(lesson.TeacherId);

        if (lesson is null)
            throw new NotImplementedException();

        return new GetLessonResponse(lesson.Date, student!, teacher!);
    }
}
