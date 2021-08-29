using System;
using System.Collections.Generic;
using System.Net;
using ConfitecWebAPI.Domain.Interfaces.Services;
using ConfitecWebAPI.Models;
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
        public IActionResult Get([FromQuery]Targs args)
        {
            Resposta<KeyValuePair<long, IEnumerable<T>>> resposta = new Resposta<KeyValuePair<long, IEnumerable<T>>>();

            try
            {
                var registros = service.GetPaged(args);

                resposta.Sucesso = true;
                resposta.Status = HttpStatusCode.OK;
                resposta.Retorno = registros;

                return Ok(resposta);
            }
            catch (Exception ex)
            {
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.InternalServerError;
                resposta.Erros = new List<string> { $"Erro ao buscar { typeof(T).Name }: { ex.Message }" };

                return StatusCode((int)HttpStatusCode.InternalServerError, resposta);
            }
        }
    }
}