using ConfitecWenAPI.Domain.Aggregations.Base;

namespace ConfitecWebAPI.Domain.Interfaces.Services
{
    public interface IServiceCrudBase<T> 
        where T : BaseDomain
    {
        bool Insert(T domain);
        bool Delete(T domain);
        bool Update(T domain);
        T Get(int id);
    }
}
