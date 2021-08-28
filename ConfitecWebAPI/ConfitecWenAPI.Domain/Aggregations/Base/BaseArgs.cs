using System;
using System.Collections.Generic;
using System.Text;

namespace ConfitecWenAPI.Domain.Aggregations.Base
{
    public class BaseArgs
    {
        public int Id { get; set; }
        public int PaginacaoInicio { get; set; } = 1;
        public int PaginacaoQuantidade { get; set; } = 10;
    }
}
