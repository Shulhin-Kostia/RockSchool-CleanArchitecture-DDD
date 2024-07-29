using BuildingBlocks.Domain;
using Lessons.Domain.Aggregates.Teachers;
using Lessons.Domain.Teachers;

namespace Lessons.Domain.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher, TeacherId>
    {
    }
}
