using System;
using System.Collections.Generic;
using System.Text;

namespace ConfitecWebAPI.Domain.Exceptions
{
    public class ValidacaoException : Exception
    {
        public ValidacaoException(string message) : base(message) { }
    }
}
