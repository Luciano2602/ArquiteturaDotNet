using Solution.Domain.Enum;
using System;

namespace Solution.Infrastructure.DataAccessObject
{
    public class Usuario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public StatusUsuarioEnum Status { get; set; }
    }
}
