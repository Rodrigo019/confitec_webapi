using ConfitecWebAPI.Domain.Interfaces.Mapping;
using ConfitecWebAPI.Repository.Context;
using ConfitecWenAPI.Domain.Aggregations.Base;

namespace ConfitecWebAPI.Repository.Base
{
    public class InsertBase<TDomain, TEntity>
        where TDomain : BaseDomain
        where TEntity : BaseEntity
    {
        private readonly IMapConfig mapper;
        private readonly ConfitecWebAPIContext context;

        public InsertBase(ConfitecWebAPIContext context, IMapConfig mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public TDomain Insert(TDomain domain)
        {
            TEntity entity = mapper.Map<TDomain, TEntity>(domain);

            context.Add(entity);
            context.SaveChanges();

            return mapper.Map<TEntity, TDomain>(entity);
        }
    }
}
