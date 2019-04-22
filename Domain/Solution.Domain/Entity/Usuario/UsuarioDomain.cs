using Solution.Domain.Enum;
using Solution.Domain.ValueObject;
using System;

namespace Solution.Domain.Entity
{
    public class UsuarioDomain
    {
        public UsuarioDomain(NomeCompleto nome, DateTime dataNascimento, StatusUsuarioEnum status)
        {
            NomeCompleto = nome;
            DataNascimento = dataNascimento;
            Status = status;
        }

        public UsuarioDomain(int codigo, NomeCompleto nome, DateTime dataNascimento, StatusUsuarioEnum status)
        {
            Codigo = codigo;
            NomeCompleto = nome;
            DataNascimento = dataNascimento;
            Status = status;
        }

        public void Criar()
        {
            Codigo = 0;
            Status = StatusUsuarioEnum.Ativo;
        }

        public void Excluir()
        {
            Status = StatusUsuarioEnum.Excluido;
        }
        
        public int Codigo { get; private set; }
        public NomeCompleto NomeCompleto { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public StatusUsuarioEnum Status { get; private set; }
    }
}
