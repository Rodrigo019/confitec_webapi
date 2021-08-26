using ConfitecWenAPI.Domain.Aggregations.Base;

namespace ConfitecWenAPI.Domain.Services.Repositories
{
    public interface IServiceDelete<T>
        where T : BaseDomain
    {
        bool Delete(T domain);
    }
}
