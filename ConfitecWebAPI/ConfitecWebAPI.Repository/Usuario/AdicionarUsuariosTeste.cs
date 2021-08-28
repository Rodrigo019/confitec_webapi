using ConfitecWebAPI.Repository.Context;
using ConfitecWebAPI.Repository.Entities;
using System;
using System.Collections.Generic;

namespace ConfitecWebAPI.Repository.Usuario
{
    public static class AdicionarUsuariosTeste
    {
        public static void Adicionar(ConfitecWebAPIContext context)
        {
            List<UsuarioEntity> usuarios = new List<UsuarioEntity>();

            Random random = new Random();
            DateTime startDate = new DateTime(2020, 1, 1);
            int rangeDate = (DateTime.Today - startDate).Days;

            for (int cont = 1; cont <= 50; cont++)
            {
                usuarios.Add(new UsuarioEntity
                {
                    Nome = $"Usuário{cont}",
                    Sobrenome = $"Sobrenome{cont}",
                    Email = $"usuario{cont}@sobrenome{cont}.com.br",
                    DataNascimento = startDate.AddDays(random.Next(rangeDate)),
                    Escolaridade = (short)random.Next(0, 3),
                });
            }

            context.AddRange(usuarios);
            context.SaveChanges();
        }
    }
}
