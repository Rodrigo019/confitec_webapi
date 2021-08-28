using ConfitecWenAPI.Domain.Aggregations.Base;
using System.Collections.Generic;

namespace ConfitecWebAPI.Domain.Interfaces.Services
{
    public interface IServicePaged<T,Targs>
        where T : BaseDomain
        where Targs : BaseArgs
    {
        KeyValuePair<long, IEnumerable<T>> GetPaged(Targs args);
    }
}
