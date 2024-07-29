using BuildingBlocks.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lessons.Infrastructure;

public abstract class BaseRepository<T, TId>(LessonsContext context) : IRepository<T, TId>
    where T : Entity<TId>
    where TId : TypedIdValueBase
{
    protected readonly LessonsContext _context = context;

    public async Task<IEnumerable<T>?> Get()
    {
        throw new NotImplementedException();
    }

    public async Task<T?> GetById(TId id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task Insert(T lesson)
    {
        throw new NotImplementedException();
    }

    public async Task Update(T lesson)
    {
        throw new NotImplementedException();
    }
}
