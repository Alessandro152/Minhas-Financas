using System;

namespace MinhasFinancas.ViewModel.ViewModels
{
    public class MovimentoFinanceiroViewModel
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public int Tipo { get; set; }
    }
}
