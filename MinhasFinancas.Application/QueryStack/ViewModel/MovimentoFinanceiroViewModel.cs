using System;

namespace MinhasFinancas.Application.QueryStack.ViewModel
{
    public class MovimentoFinanceiroViewModel
    {
        public Guid Id { get; set; }

        public decimal Valor { get; set; }

        public string Titulo { get; set; }

        public DateTime Data { get; set; }

        public int Tipo { get; set; }

        public Guid ClienteId { get; set; }
    }
}
