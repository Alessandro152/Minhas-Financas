using System;

namespace MinhasFinancas.ViewModel.ViewModels
{
    public class MovimentoFinanceiroViewModel
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}
