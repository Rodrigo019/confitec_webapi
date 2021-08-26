using System;
using System.Collections.Generic;
using System.Net;

namespace ConfitecWebAPI.Models
{
    public class Resposta
    {
        public bool Sucesso { get; set; }
        public HttpStatusCode Status { get; set; }
        public IEnumerable<string> Erros { get; set; }
    }
}
