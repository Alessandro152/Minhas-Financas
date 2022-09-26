using MinhasFinancas.Domain.Enum;
using System;

namespace MinhasFinancas.Application.QueryStack.ViewModel
{
    public class NewMovimentoFinanceiroViewModel
    {
        public decimal Valor { get; set; }

        public string Titulo { get; set; }

        public DateTime Data { get; set; }

        public TipoFinanceiroEnum Tipo { get; set; }

        public Guid ClienteId { get; set; }
    }
}
