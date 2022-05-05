using MinhasFinancas.Domain.Core.Shared;
using System;

namespace MinhasFinancas.Domain.Financas.Commands
{
    public class NewMovimentoFinanceiroCommand : Command
    {
        public NewMovimentoFinanceiroCommand(decimal valor, string titulo, DateTime data, int tipo, Guid clienteId)
        {
            Valor = valor;
            Titulo = titulo;
            Data = data;
            Tipo = tipo;
            ClienteId = clienteId;
        }

        public decimal Valor { get; }

        public string Titulo { get; }

        public DateTime Data { get; }

        public int Tipo { get; }

        public Guid ClienteId { get; }
    }
}
