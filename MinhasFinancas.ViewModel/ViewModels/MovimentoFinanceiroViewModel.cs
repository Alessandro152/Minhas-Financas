using System;
using System.Collections.Generic;

namespace MinhasFinancas.ViewModel.ViewModels
{
    public class MovimentoFinanceiroViewModel
    {
        public int Id { get; set; }
        public IEnumerable<MovimentoFinanceiroValoresViewModel> Valores { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}
