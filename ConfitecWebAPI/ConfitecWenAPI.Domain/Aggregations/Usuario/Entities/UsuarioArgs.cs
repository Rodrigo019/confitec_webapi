using ConfitecWenAPI.Domain.Aggregations.Base;
using ConfitecWenAPI.Domain.ObjectValues;

namespace ConfitecWebAPI.Domain.Aggregations.Usuario.Entities
{
    public class UsuarioArgs : BaseArgs
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public Escolaridade? Escolaridade { get; set; }
    }
}
