using ConfitecWebAPI.Domain.Aggregations.Usuario.Entities;
using ConfitecWebAPI.Domain.Aggregations.Usuario.Interfaces;
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
        public bool Delete(UsuarioDomain domain)
        {
            throw new NotImplementedException();
        }
        public UsuarioDomain Get(int id)
        {
            throw new NotImplementedException();
        }
        public bool Insert(UsuarioDomain domain)
        {
            if (!domain.EmailValido)
                throw new Exception("O e-mail do usuário é inválido!");
            if (!domain.DataNascimentoValida)
                throw new Exception("Data de nascimento do usuário é inválida!");

            return repository.Insert(domain);
        }
        public bool Update(UsuarioDomain domain)
        {
            throw new NotImplementedException();
        }
    }
}
