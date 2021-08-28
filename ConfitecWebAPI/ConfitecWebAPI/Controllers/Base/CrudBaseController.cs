using System;
using System.Collections.Generic;
using System.Net;
using ConfitecWebAPI.Domain.Exceptions;
using ConfitecWebAPI.Domain.Interfaces.Services;
using ConfitecWebAPI.Models;
using ConfitecWenAPI.Domain.Aggregations.Base;
using Microsoft.AspNetCore.Mvc;

namespace ConfitecWebAPI.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudBaseController<T> : ControllerBase
        where T : BaseDomain
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
                T retorno = service.Get(id);

                return Ok(retorno);
            }
            catch (ValidacaoException vEx)
            {
                Resposta resposta = new Resposta();
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.BadRequest;
                resposta.Erros = new List<string> { $"Erro ao buscar { typeof(T).Name } { id }: { vEx.Message }" };

                return BadRequest(resposta);
            }
            catch (Exception ex)
            {
                Resposta resposta = new Resposta();
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.InternalServerError;
                resposta.Erros = new List<string> { $"Erro ao buscar { typeof(T).Name }  { id }: { ex.Message }" };

                return StatusCode(500, resposta);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]T domain)
        {
            try
            {
                T modelInserida = service.Insert(domain);

                if (modelInserida.Id > 0)
                    return StatusCode(201, modelInserida);

                throw new Exception("Não foi possível inserir!");
            }
            catch (ValidacaoException vEx)
            {
                Resposta resposta = new Resposta();
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.UnprocessableEntity;
                resposta.Erros = new List<string> { $"Erro ao inserir { typeof(T).Name }: { vEx.Message }" };

                return UnprocessableEntity(resposta);
            }
            catch (Exception ex)
            {
                Resposta resposta = new Resposta();
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.InternalServerError;
                resposta.Erros = new List<string> { $"Erro ao inserir { typeof(T).Name }: { ex.Message }" };

                return StatusCode(500, resposta);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]T domain)
        {
            try
            {
                T modelAlterada = service.Update(domain);

                if (modelAlterada.Id > 0)
                    return Ok(modelAlterada);

                throw new Exception("Não foi possível alterar!");
            }
            catch (ValidacaoException vEx)
            {
                Resposta resposta = new Resposta();
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.UnprocessableEntity;
                resposta.Erros = new List<string> { $"Erro ao alterar { typeof(T).Name }: { vEx.Message }" };

                return UnprocessableEntity(resposta);
            }
            catch (Exception ex)
            {
                Resposta resposta = new Resposta();
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.InternalServerError;
                resposta.Erros = new List<string> { $"Erro ao alterar { typeof(T).Name }: { ex.Message }" };

                return StatusCode(500, resposta);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool retorno = service.Delete(id);
                Resposta resposta = new Resposta();

                if (retorno)
                {
                    resposta.Sucesso = true;
                    resposta.Status = HttpStatusCode.OK;

                    return Ok(resposta);
                }
                else
                    throw new Exception("Um erro interno ocorreu!");                
            }
            catch (ValidacaoException vEx)
            {
                Resposta resposta = new Resposta();
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.BadRequest;
                resposta.Erros = new List<string> { $"Erro ao deletar { typeof(T).Name }: { vEx.Message }" };

                return BadRequest(resposta);
            }
            catch (Exception ex)
            {
                Resposta resposta = new Resposta();
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.InternalServerError;
                resposta.Erros = new List<string> { $"Erro ao deletar { typeof(T).Name } { id }: { ex.Message }" };

                return StatusCode(500, resposta);
            }
        }
    }
}