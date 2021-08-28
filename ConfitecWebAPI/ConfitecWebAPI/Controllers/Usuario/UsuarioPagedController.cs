using ConfitecWebAPI.Controllers.Base;
using ConfitecWebAPI.Domain.Aggregations.Usuario.Entities;
using ConfitecWebAPI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConfitecWebAPI.Controllers.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioPagedController : PagedBaseController<UsuarioDomain, UsuarioArgs>
    {
        public UsuarioPagedController(IServicePaged<UsuarioDomain, UsuarioArgs> service) : base(service)
        {
        }
    }
}