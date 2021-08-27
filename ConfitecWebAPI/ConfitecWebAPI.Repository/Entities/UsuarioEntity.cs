using ConfitecWebAPI.Repository.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConfitecWebAPI.Repository.Entities
{
    public class UsuarioEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo é obrigatório")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage ="Este campo é obrigatório")]
        [MaxLength(30, ErrorMessage = "Este campo é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public short Escolaridade { get; set; }
    }
}
