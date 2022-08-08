namespace MinhasFinancas.Domain.Core.ValueObjects
{
    public class EnderecoVO
    {
        //EF
        public EnderecoVO()
        {

        }

        public EnderecoVO(string cidade, string uf)
        {
            Cidade = cidade;
            UF = uf;
        }

        public string Cidade { get; private set; }

        public string UF { get; private set; }
    }
}
