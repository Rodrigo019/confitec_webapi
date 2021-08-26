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
    public class CrudBaseController<T,Targs> : ControllerBase
        where T : BaseDomain
        where Targs : BaseArgs
    {
        private readonly IServiceCrudBase<T> service;

        public CrudBaseController(IServiceCrudBase<T> service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    Resposta resposta = new Resposta();
                    resposta.Sucesso = false;
                    resposta.Status = HttpStatusCode.BadRequest;
                    resposta.Erros = new List<string> { "Não é possível buscar usuários com Id 0 ou menor!" };

                    return BadRequest(resposta);
                }

                T retorno = service.Get(id);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                Resposta resposta = new Resposta();
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.InternalServerError;
                resposta.Erros = new List<string> { $"Erro ao buscar usuário { id }: { ex.Message }" };

                return StatusCode(500, resposta);
            }
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody]T model)
        {
            try
            {
                bool retorno = service.Insert(model);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                Resposta resposta = new Resposta();
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.InternalServerError;
                resposta.Erros = new List<string> { $"Erro ao inserir usuário: { ex.Message }" };

                return StatusCode(500, resposta);
            }
        }
    }
}