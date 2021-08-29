using ConfitecWebAPI.Domain.Aggregations.Usuario.Entities;
using ConfitecWebAPI.Domain.Aggregations.Usuario.Interfaces;
using ConfitecWebAPI.Domain.Exceptions;
using ConfitecWebAPI.Domain.Interfaces.Mapping;
using ConfitecWebAPI.Repository.Base;
using ConfitecWebAPI.Repository.Context;
using ConfitecWebAPI.Repository.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ConfitecWebAPI.Repository.Usuario
{
    public class UsuarioRepository : 
        InsertBase<UsuarioDomain, UsuarioEntity>, IUsuarioRepository
    {
        private readonly IMapConfig mapper;
        private readonly ConfitecWebAPIContext context;

        public UsuarioRepository(ConfitecWebAPIContext context, IMapConfig mapper) : base(context, mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public bool Delete(int id)
        {
            UsuarioEntity entity = context.Usuarios.FirstOrDefault(x => x.Id == id);

            if (entity == null)
                throw new ValidacaoException($"Usuário { id } não encontrado!");

            context.Remove(entity);

            return context.SaveChanges() > 0;
        }

        public UsuarioDomain Get(int id)
        {
            UsuarioEntity entity = context.Usuarios.FirstOrDefault(x => x.Id == id);
            return mapper.Map<UsuarioEntity, UsuarioDomain>(entity);
        }

        public KeyValuePair<long, IEnumerable<UsuarioDomain>> GetPaged(UsuarioArgs args)
        {
            List<UsuarioEntity> usuariosFiltrados = context.Usuarios
                .Where(x => args.Id > 0 ? x.Id == args.Id : true)
                .Where(x => !string.IsNullOrEmpty(args.Nome) ? x.Nome.Contains(args.Nome) : true)
                .Where(x => !string.IsNullOrEmpty(args.Sobrenome) ? x.Sobrenome.Contains(args.Sobrenome) : true)
                .Where(x => args.Escolaridade != null ? x.Escolaridade == (short)args.Escolaridade : true)
                .ToList();

            List<UsuarioEntity> usuarios = usuariosFiltrados
                .Skip((args.PaginacaoInicio - 1) * args.PaginacaoQuantidade)
                .Take(args.PaginacaoQuantidade)
                .ToList();            

            List<UsuarioDomain> usuariosDomain = mapper.Map<List<UsuarioEntity>, List<UsuarioDomain>>(usuarios);
            return new KeyValuePair<long, IEnumerable<UsuarioDomain>>(usuariosFiltrados.Count(), usuariosDomain);
        }

        public UsuarioDomain Update(UsuarioDomain domain)
        {
            UsuarioEntity entity = context.Usuarios.FirstOrDefault(x => x.Id == domain.Id);

            if (entity == null)
                throw new ValidacaoException($"Usuário { domain.Id } não encontrado!");

            entity.Nome = domain.Nome;
            entity.Sobrenome = domain.Sobrenome;
            entity.Email = domain.Email;
            entity.DataNascimento = domain.DataNascimento;
            entity.Escolaridade = (short)domain.Escolaridade;

            context.SaveChanges();

            return mapper.Map<UsuarioEntity, UsuarioDomain>(entity);
        }
    }
}
