using MinhasFinancas.Domain.Core.Shared;
using System;

namespace MinhasFinancas.Domain.Financas.Commands
{
    public class UpdateMovimentoFinanceiroCommand : Command
    {
        public UpdateMovimentoFinanceiroCommand(Guid id, decimal valor, string titulo, DateTime data, int tipo, Guid clienteId)
        {
            Id = id;
            Valor = valor;
            Titulo = titulo;
            Data = data;
            Tipo = tipo;
            ClienteId = clienteId;
        }

        public Guid Id { get; }

        public decimal Valor { get; }

        public string Titulo { get; }

        public DateTime Data { get; }

        public int Tipo { get; }

        public Guid ClienteId { get; }
    }
}
