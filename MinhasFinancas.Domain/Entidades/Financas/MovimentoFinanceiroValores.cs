using MinhasFinancas.Domain.Core.Enums;
using MinhasFinancas.Domain.Core.Shared;

namespace MinhasFinancas.Domain.Entidades.Financas
{
    public class MovimentoFinanceiroValores : Entidade
    {
        public MovimentoFinanceiroValores()
        {

        }

        public MovimentoFinanceiroValores(decimal valor,
                                          SimNaoEnum? pago,
                                          SimNaoEnum? recebido)
        {
            Valor = valor;
            Pago = pago;
            Recebido = recebido;
        }

        public decimal Valor { get; }
        public SimNaoEnum? Pago { get; private set; }
        public SimNaoEnum? Recebido { get; private set; }

        public int MovimentoFinanceiroId { get; private set; }

        internal void DefinirDespesaComoPago()
            => Pago = SimNaoEnum.Sim;

        internal void DefinirReceitaComoRecebido()
            => Recebido = SimNaoEnum.Sim;
    }
}
