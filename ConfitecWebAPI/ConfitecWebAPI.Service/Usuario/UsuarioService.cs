using ConfitecWebAPI.Domain.Aggregations.Usuario.Entities;
using ConfitecWebAPI.Domain.Aggregations.Usuario.Interfaces;
using ConfitecWebAPI.Domain.Exceptions;
using System;

namespace ConfitecWebAPI.Service.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            this.repository = repository;
        }
        public bool Delete(int id)
        {
            if (id <= 0)
                throw new ValidacaoException("Não é possível deletar usuários com Id 0 ou menor!");

            return repository.Delete(id);
        }
        public UsuarioDomain Get(int id)
        {
            if (id <= 0)
                throw new ValidacaoException("Não é possível buscar usuários com Id 0 ou menor!");

            return repository.Get(id);
        }
        public UsuarioDomain Insert(UsuarioDomain domain)
        {
            if (domain == null)
                throw new ValidacaoException("Usuário informado não pode ser nulo!");
            if (!domain.EmailValido())
                throw new ValidacaoException("O e-mail do usuário é inválido!");
            if (!domain.DataNascimentoValida())
                throw new ValidacaoException("Data de nascimento do usuário é inválida!");

            return repository.Insert(domain);
        }
        public UsuarioDomain Update(UsuarioDomain domain)
        {
            if (domain == null || domain.Id <= 0)
                throw new ValidacaoException("Não é possível alterar usuários com Id 0 ou menor!");
            if (!domain.EmailValido())
                throw new ValidacaoException("O e-mail do usuário é inválido!");
            if (!domain.DataNascimentoValida())
                throw new ValidacaoException("Data de nascimento do usuário é inválida!");

            return repository.Update(domain);
        }
    }
}
