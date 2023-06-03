using System;

namespace MinhasFinancas.ViewModel.ViewModels
{
    public class NewMovimentoFinanceiroViewModel
    {
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int Tipo { get; set; }
        public int UsuarioId { get; set; }
    }
}
