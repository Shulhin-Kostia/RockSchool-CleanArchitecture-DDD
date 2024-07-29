using BuildingBlocks.Domain;
using Lessons.Domain.Aggregates.Students;

namespace Lessons.Domain.Repositories
{
    public interface IStudentRepository : IRepository<Student, StudentId>
    {
    }
}
