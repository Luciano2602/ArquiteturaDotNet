using Solution.Domain.Command;
using Solution.Domain.Entity;
using Solution.Domain.ValueObject;
using Solution.Infrastructure.DataAccessObject;

namespace Solution.Domain.Factory
{
    public static class UsuarioFactory
    {
        public static UsuarioDomain Criar(UsuarioBaseCommand command)
        {
            return new UsuarioDomain(new NomeCompleto(command.Nome, command.SobreNome), command.DataNascimento, command.Status);
        }

        public static UsuarioDomain Alterar(UsuarioUpdateCommand command)
        {
            return UpdateBase(command, command.Codigo);
        }

        public static UsuarioDomain Excluir(UsuarioDeleteCommand command)
        {
            return UpdateBase(command, command.Codigo);       
        }
        
        public static UsuarioDomain Status(UsuarioStatusCommand command)
        {
            return UpdateBase(command, command.Codigo);
        }
        private static UsuarioDomain UpdateBase(UsuarioBaseCommand command, int Id)
        {
            return new UsuarioDomain(Id, new NomeCompleto(command.Nome, command.SobreNome), command.DataNascimento, command.Status);
        }

        public static Usuario ToEntity(UsuarioDomain domain)
        {
            return new Usuario();
        }
    }
}
