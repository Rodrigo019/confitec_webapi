using System;
using System.Collections.Generic;
using System.Net;

namespace ConfitecWebAPI.Models
{
    public class Resposta<T>
    {
        public bool Sucesso { get; set; }
        public HttpStatusCode Status { get; set; }
        public IEnumerable<string> Erros { get; set; }
        public T Retorno { get; set; }
    }
}
