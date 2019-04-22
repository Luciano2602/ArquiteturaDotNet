using Solution.Domain.Enum;
using System;

namespace Solution.Api.ViewModel
{
    public class UsuarioViewModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public StatusUsuarioEnum Status { get; set; }
    }
}
