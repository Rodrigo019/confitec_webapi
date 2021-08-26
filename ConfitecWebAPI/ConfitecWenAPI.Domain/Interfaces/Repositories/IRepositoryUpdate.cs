using ConfitecWenAPI.Domain.Aggregations.Base;

namespace ConfitecWenAPI.Domain.Interfaces.Repositories
{
    public interface IServiceUpdate<T>
        where T : BaseDomain
    {
        bool Update(T domain);
    }
}
