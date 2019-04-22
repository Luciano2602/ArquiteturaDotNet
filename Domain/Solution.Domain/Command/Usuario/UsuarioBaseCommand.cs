using Solution.Domain.Enum;
using System;

namespace Solution.Domain.Command
{
    public class UsuarioBaseCommand
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public StatusUsuarioEnum Status { get; set; }
        public bool Ativo { get; set; }
    }
}
