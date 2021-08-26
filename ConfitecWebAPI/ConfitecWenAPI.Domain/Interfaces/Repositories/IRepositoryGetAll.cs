using ConfitecWenAPI.Domain.Aggregations.Base;
using System.Collections.Generic;

namespace ConfitecWenAPI.Domain.Interfaces.Repositories
{
    public interface IServiceGetAll<T,Targs>
        where T : BaseDomain
        where Targs : BaseArgs
    {
        IEnumerable<T> GetAll(Targs args);
    }
}
