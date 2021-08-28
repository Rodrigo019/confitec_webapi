using ConfitecWebAPI.Domain.Exceptions;
using ConfitecWenAPI.Domain.Aggregations.Base;
using ConfitecWenAPI.Domain.ObjectValues;
using ConfitecWenAPI.Domain.Validators;
using System;

namespace ConfitecWebAPI.Domain.Aggregations.Usuario.Entities
{
    public class UsuarioDomain : BaseDomain
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Escolaridade Escolaridade { get; set; }

        public void IdValido()
        {
            if (Id <= 0) 
                throw new ValidacaoException("O Id informado precisa ser maior que 0!");
        }
        public void EmailValido()
        {
            if (!ValidaEmail.Valido(Email))
                throw new ValidacaoException("O Email informado é inválido!");
        } 
        public void DataNascimentoValida()
        {
            if (DataNascimento > DateTime.Now)
                throw new ValidacaoException("A Data de Nascimento informada é inválida!");
        }
    }
}
