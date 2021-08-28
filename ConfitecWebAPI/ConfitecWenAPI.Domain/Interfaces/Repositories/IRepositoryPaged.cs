using ConfitecWenAPI.Domain.Aggregations.Base;
using System.Collections.Generic;

namespace ConfitecWebAPI.Domain.Interfaces.Repositories
{
    public interface IRepositoryPaged<T, Targs>
        where T : BaseDomain
        where Targs : BaseArgs
    {
        KeyValuePair<long, IEnumerable<T>> GetPaged(Targs args);
    }
}
