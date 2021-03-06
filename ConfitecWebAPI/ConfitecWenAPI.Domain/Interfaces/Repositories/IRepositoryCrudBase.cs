using ConfitecWenAPI.Domain.Aggregations.Base;

namespace ConfitecWebAPI.Domain.Interfaces.Repositories
{
    public interface IRepositoryCrudBase<T>
        where T : BaseDomain
    {
        bool Delete(int id);
        T Update(T domain);
        T Get(int id);
    }
}
