using ConfitecWenAPI.Domain.Aggregations.Base;

namespace ConfitecWebAPI.Domain.Interfaces.Services
{
    public interface IServiceCrudBase<T> 
        where T : BaseDomain
    {
        T Insert(T domain);
        bool Delete(int id);
        T Update(T domain);
        T Get(int id);
    }
}
