using MinhasFinancas.Domain.Core.Enums;
using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhasFinancas.Domain.Entidades.Financas
{
    public class MovimentoFinanceiro : Entidade
    {
        private readonly List<MovimentoFinanceiroValores> _movimentoFinanceiroValores;

        public MovimentoFinanceiro()
        {
            _movimentoFinanceiroValores = new List<MovimentoFinanceiroValores>();

        }

        public MovimentoFinanceiro(string descricao, 
                                   DateTime dataVencimento, 
                                   TipoMovimentoEnum tipo,
                                   int usuarioId) : this()
        {
            Descricao = descricao;
            DataVencimento = dataVencimento.Date;
            Tipo = tipo;
            UsuarioId = usuarioId;
        }

        public string Descricao { get; }
        public DateTime DataVencimento { get; }
        public DateTime DataEfetivacao { get; private set; }
        public TipoMovimentoEnum Tipo { get; }
        public int UsuarioId { get; }
        public IEnumerable<MovimentoFinanceiroValores> MovimentoFinanceiroValores => _movimentoFinanceiroValores;

        internal void AdicionarValores(decimal valor,
                                       SimNaoEnum? pago,
                                       SimNaoEnum? recebido)
            => _movimentoFinanceiroValores.Add(new MovimentoFinanceiroValores(valor, pago, recebido));

        internal void DefinirDespesaComoPago(int id)
        {
            MovimentoFinanceiroValores.Where(x => x.MovimentoFinanceiroId == id)
                                      .First()
                                      .DefinirDespesaComoPago();

            DataEfetivacao = DateTime.Now.Date;
        }

        internal void DefinirReceitaComoRecebido(int id)
        {
            MovimentoFinanceiroValores.Where(x => x.MovimentoFinanceiroId == id)
                                      .First()
                                      .DefinirReceitaComoRecebido();

            DataEfetivacao = DateTime.Now.Date;
        }
    }
}
