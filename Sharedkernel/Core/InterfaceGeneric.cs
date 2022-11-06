namespace Sharedkernel.Core
{
    public interface InterfaceGeneric<T, in TId> where T : AggregateRoot<TId>
    {

        Task<T> FindByIdAsync(TId id);

        Task CreateAsync(T obj);



    }
}
