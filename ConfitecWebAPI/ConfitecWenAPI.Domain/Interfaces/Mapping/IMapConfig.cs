
namespace ConfitecWebAPI.Domain.Interfaces.Mapping
{
    public interface IMapConfig
    {
        T Map<T>(object data);
        Tout Map<Tin, Tout>(Tin data);
    }
}
