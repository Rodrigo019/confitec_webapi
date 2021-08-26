using ConfitecWenAPI.Domain.Aggregations.Base;

namespace ConfitecWenAPI.Domain.Services.Repositories
{
    interface IServiceInsert<T>
        where T : BaseDomain
    {
        bool Insert(T domain);
    }
}
