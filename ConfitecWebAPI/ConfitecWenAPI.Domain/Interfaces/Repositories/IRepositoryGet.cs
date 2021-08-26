using ConfitecWenAPI.Domain.Aggregations.Base;

namespace ConfitecWenAPI.Domain.Interfaces.Repositories
{
    public interface IServiceGet<T,Targs>
        where T : BaseDomain
        where Targs: BaseArgs
    {
        T Get(Targs args);
    }
}
