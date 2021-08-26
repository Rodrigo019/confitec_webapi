using ConfitecWenAPI.Domain.Aggregations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfitecWebAPI.Domain.Interfaces.Repositories
{
    public interface IRepositoryCrudBase<T>
        where T : BaseDomain
    {
        bool Insert(T domain);
        bool Delete(T domain);
        bool Update(T domain);
        T Get(int id);
    }
}
