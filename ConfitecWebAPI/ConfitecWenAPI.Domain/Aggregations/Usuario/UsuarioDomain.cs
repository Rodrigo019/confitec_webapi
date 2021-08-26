﻿using ConfitecWenAPI.Domain.Aggregations.Base;
using ConfitecWenAPI.Domain.ObjectValues;
using ConfitecWenAPI.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConfitecWenAPI.Domain.Aggregations.Usuario
{
    public class UsuarioDomain : BaseDomain
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Escolaridade Escolaridade { get; set; }

        public bool EmailValido => ValidaEmail.Valido(Email);            
        public bool DataNascimentoValida => DataNascimento <= DateTime.Now;
    }
}