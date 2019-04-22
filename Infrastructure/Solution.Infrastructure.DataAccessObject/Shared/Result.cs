using System.Collections.Generic;
using FluentValidation.Results;

namespace Solution.Infrastructure.DataAccessObject
{
    public class Result
    {
        public bool Valido { get; private set; }
        public List<Mensagem> Mensagens { get; private set; }
        public object Objeto { get; private set; }

        public Result()
        {
            Mensagens = new List<Mensagem>();
            Valido = true;
        }

        public void AdicionarMensagem(IList<ValidationFailure> mensagens)
        {
            foreach(var mensagem in mensagens)
            {
                Mensagens.Add(new Mensagem(mensagem.PropertyName, mensagem.ErrorMessage));
            }
        }

        public void AdicionarMensagem(string propriedade, string nomeErro)
        {
            Mensagens.Add(new Mensagem(propriedade, nomeErro));
        }

        public void Invalidar()
        {
            Valido = false;
        }

        public void AdicionarObjeto(object objeto)
        {
            Objeto = objeto;
        }
    }
}
