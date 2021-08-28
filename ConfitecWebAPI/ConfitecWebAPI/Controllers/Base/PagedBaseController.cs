using System;
using ConfitecWebAPI.Domain.Interfaces.Services;
using ConfitecWenAPI.Domain.Aggregations.Base;
using Microsoft.AspNetCore.Mvc;

namespace ConfitecWebAPI.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagedBaseController<T, Targs> : ControllerBase
        where T : BaseDomain
        where Targs : BaseArgs
    {
        private readonly IServicePaged<T, Targs> service;
        public PagedBaseController(IServicePaged<T, Targs> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get(Targs args)
        {
            try
            {
                var resultado = service.GetPaged(args);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar { typeof(T).Name }: { ex.Message }");
            }
        }
    }
}