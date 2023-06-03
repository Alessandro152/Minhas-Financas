using MinhasFinancas.Domain.Enum;
using System;

namespace MinhasFinancas.ViewModel.ViewModels
{
    public class UpdateMovimentoFinanceiroViewModel
    {
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public TipoMovimentoEnum Tipo { get; set; }
    }
}
