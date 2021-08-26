using ConfitecWenAPI.Domain.Aggregations.Base;

namespace ConfitecWenAPI.Domain.Interfaces.Repositories
{
    public interface IServiceDelete<T>
        where T : BaseDomain
    {
        bool Delete(T domain);
    }
}
