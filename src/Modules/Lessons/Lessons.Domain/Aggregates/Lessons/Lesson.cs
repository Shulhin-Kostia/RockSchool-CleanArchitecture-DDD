using BuildingBlocks.Domain;
using Lessons.Domain.Aggregates.Students;
using Lessons.Domain.Teachers;

namespace Lessons.Domain.Aggregates.Lessons;

public class Lesson : Entity<LessonId>, IAggregateRoot
{
    public StudentId StudentId { get; init; }

    //not readonly because teacher can be swapped
    public TeacherId TeacherId { get; private set; }

    public DateTime Date { get; private set; }

    public Duration Duration { get; init; }

    public LessonStatus Status { get; private set; }

#pragma warning disable CS8618 
    private Lesson()
    {
        //For EF
    }
#pragma warning restore CS8618

    private Lesson(DateTime date, Duration duration, StudentId studentId, TeacherId teacherId)
        : base(new LessonId(Guid.NewGuid()))
    {
        StudentId = studentId;
        TeacherId = teacherId;

        Date = date;
        Duration = duration;
        Status = LessonStatus.Scheduled;
    }

    public static Lesson Create(StudentId studentId, TeacherId teacherId, DateTime dateTime, int durationMinutes)
    {
        var duration = Duration.Create(durationMinutes);

        return new Lesson(dateTime, duration, studentId, teacherId);
    }

    // public static Lesson Create(LessonId id, StudentId studentId, TeacherId teacherId, DateTime dateTime, int durationMinutes, LessonStatus status)
    // {
    //     var lesson = Create(studentId, teacherId, dateTime, durationMinutes);
    //     lesson.Id = id;
    //     lesson.Status = status;

    //     return lesson;
    // }

    public void MarkCompleted()
    {
        if (Status == LessonStatus.Scheduled)
        {
            Status = LessonStatus.Completed;
        }
    }

    public void MarkMissed()
    {
        if (Status == LessonStatus.Scheduled)
        {
            Status = LessonStatus.Missed;
        }
    }

    public void ChangeDate(DateTime newDate) => Date = newDate;

    public void ChangeTeacher(TeacherId teacherId) => TeacherId = teacherId;
}
