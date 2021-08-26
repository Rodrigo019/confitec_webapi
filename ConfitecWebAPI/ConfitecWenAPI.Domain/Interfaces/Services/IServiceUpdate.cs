using ConfitecWenAPI.Domain.Aggregations.Base;

namespace ConfitecWenAPI.Domain.Services.Repositories
{
    public interface IServiceUpdate<T>
        where T : BaseDomain
    {
        bool Update(T domain);
    }
}
