using System;
using System.Collections.Generic;
using System.Net;
using ConfitecWebAPI.Domain.Exceptions;
using ConfitecWebAPI.Domain.Interfaces.Services;
using ConfitecWebAPI.Models;
using ConfitecWenAPI.Domain.Aggregations.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            Resposta<T> resposta = new Resposta<T>();

            try
            {
                T retorno = service.Get(id);

                resposta.Sucesso = true;
                resposta.Status = HttpStatusCode.OK;
                resposta.Retorno = retorno;

                return Ok(resposta);
            }
            catch (ValidacaoException vEx)
            {
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.BadRequest;
                resposta.Erros = new List<string> { $"Erro ao buscar { typeof(T).Name } { id }: { vEx.Message }" };

                return BadRequest(resposta);
            }
            catch (Exception ex)
            {
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.InternalServerError;
                resposta.Erros = new List<string> { $"Erro ao buscar { typeof(T).Name }  { id }: { ex.Message }" };

                return StatusCode((int)HttpStatusCode.InternalServerError, resposta);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]T domain)
        {
            Resposta<T> resposta = new Resposta<T>();

            try
            {
                T modelInserida = service.Insert(domain);

                if (modelInserida.Id > 0)
                {
                    resposta.Sucesso = true;
                    resposta.Status = HttpStatusCode.Created;
                    resposta.Retorno = modelInserida;

                    return StatusCode((int)HttpStatusCode.Created, resposta);
                }

                throw new Exception("Não foi possível inserir!");
            }
            catch (ValidacaoException vEx)
            {
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.UnprocessableEntity;
                resposta.Erros = new List<string> { $"Erro ao inserir { typeof(T).Name }: { vEx.Message }" };

                return UnprocessableEntity(resposta);
            }
            catch (Exception ex)
            {
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.InternalServerError;
                resposta.Erros = new List<string> { $"Erro ao inserir { typeof(T).Name }: { ex.Message }" };

                return StatusCode((int)HttpStatusCode.InternalServerError, resposta);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]T domain)
        {
            Resposta<T> resposta = new Resposta<T>();

            try
            {
                T modelAlterada = service.Update(domain);

                if (modelAlterada.Id > 0)
                {
                    resposta.Sucesso = true;
                    resposta.Status = HttpStatusCode.OK;
                    resposta.Retorno = modelAlterada;

                    return Ok(modelAlterada);
                }

                throw new Exception("Não foi possível alterar!");
            }
            catch (ValidacaoException vEx)
            {
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.UnprocessableEntity;
                resposta.Erros = new List<string> { $"Erro ao alterar { typeof(T).Name }: { vEx.Message }" };

                return UnprocessableEntity(resposta);
            }
            catch (Exception ex)
            {
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.InternalServerError;
                resposta.Erros = new List<string> { $"Erro ao alterar { typeof(T).Name }: { ex.Message }" };

                return StatusCode((int)HttpStatusCode.InternalServerError, resposta);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Resposta<bool> resposta = new Resposta<bool>();

            try
            {
                bool retorno = service.Delete(id);

                if (retorno)
                {
                    resposta.Sucesso = true;
                    resposta.Status = HttpStatusCode.OK;
                    resposta.Retorno = retorno;

                    return Ok(resposta);
                }
                else
                    throw new Exception("Um erro interno ocorreu!");                
            }
            catch (ValidacaoException vEx)
            {
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.BadRequest;
                resposta.Erros = new List<string> { $"Erro ao deletar { typeof(T).Name }: { vEx.Message }" };

                return BadRequest(resposta);
            }
            catch (Exception ex)
            {
                resposta.Sucesso = false;
                resposta.Status = HttpStatusCode.InternalServerError;
                resposta.Erros = new List<string> { $"Erro ao deletar { typeof(T).Name } { id }: { ex.Message }" };

                return StatusCode((int)HttpStatusCode.InternalServerError, resposta);
            }
        }
    }
}