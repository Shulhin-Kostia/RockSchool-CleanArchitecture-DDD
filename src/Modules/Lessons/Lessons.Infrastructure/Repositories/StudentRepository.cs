using Lessons.Domain.Aggregates.Students;
using Lessons.Domain.Repositories;

namespace Lessons.Infrastructure.Repositories;

public class StudentRepository(LessonsContext context) : BaseRepository<Student, StudentId>(context), IStudentRepository
{

}
