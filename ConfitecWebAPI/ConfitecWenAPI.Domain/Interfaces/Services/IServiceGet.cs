using ConfitecWenAPI.Domain.Aggregations.Base;

namespace ConfitecWenAPI.Domain.Services.Repositories
{
    public interface IServiceGet<T,Targs>
        where T : BaseDomain
        where Targs: BaseArgs
    {
        T Get(Targs args);
    }
}
