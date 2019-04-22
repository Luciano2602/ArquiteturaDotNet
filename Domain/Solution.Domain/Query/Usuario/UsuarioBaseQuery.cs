using Solution.Domain.Enum;
using System;

namespace Solution.Domain.Query
{
    public abstract class UsuarioBaseQuery
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public StatusUsuarioEnum Status { get; set; }
        public bool Ativo { get; set; }
    }
}
