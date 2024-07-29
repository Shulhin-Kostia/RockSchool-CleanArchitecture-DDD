namespace BuildingBlocks.Domain
{
    public interface IRepository<T, TId>
        where T : Entity<TId>
        where TId : TypedIdValueBase
    {
        Task<IEnumerable<T>?> Get();

        Task<T?> GetById(TId id);

        Task Insert(T lesson);

        Task Update(T lesson);
    }
}
