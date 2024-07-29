using Lessons.Domain.Aggregates.Teachers;
using Lessons.Domain.Repositories;
using Lessons.Domain.Teachers;

namespace Lessons.Infrastructure.Repositories;

public class TeacherRepository(LessonsContext context) : BaseRepository<Teacher, TeacherId>(context), ITeacherRepository
{

}
