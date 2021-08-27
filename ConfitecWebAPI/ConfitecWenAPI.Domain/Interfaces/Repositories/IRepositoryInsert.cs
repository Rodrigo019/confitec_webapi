using ConfitecWenAPI.Domain.Aggregations.Base;

namespace ConfitecWebAPI.Domain.Interfaces.Repositories
{
    public interface IRepositoryInsert<T>
        where T : BaseDomain
    {
        T Insert(T domain);
    }
}
