namespace Solution.Infrastructure.DataAccessObject
{
    public class Mensagem
    {
        public Mensagem(string propriedade, string descricao)
        {
            Propriedade = propriedade;
            Descricao = descricao;
        }

        public string Propriedade { get; private set; }
        public string Descricao { get; private set; }
    }
}
