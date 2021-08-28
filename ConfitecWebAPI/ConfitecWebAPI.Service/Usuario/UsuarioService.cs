using ConfitecWebAPI.Domain.Aggregations.Usuario.Entities;
using ConfitecWebAPI.Domain.Aggregations.Usuario.Interfaces;
using ConfitecWebAPI.Domain.Exceptions;
using System.Collections.Generic;

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

        public KeyValuePair<long, IEnumerable<UsuarioDomain>> GetPaged(UsuarioArgs args)
        {
            return repository.GetPaged(args);
        }

        public UsuarioDomain Insert(UsuarioDomain domain)
        {
            domain.EmailValido();
            domain.DataNascimentoValida();

            return repository.Insert(domain);
        }
        public UsuarioDomain Update(UsuarioDomain domain)
        {
            domain.IdValido();
            domain.EmailValido();
            domain.DataNascimentoValida();

            return repository.Update(domain);
        }
    }
}
