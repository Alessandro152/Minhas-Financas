using MinhasFinancas.Domain.Enum;
using System;

namespace MinhasFinancas.Domain.Commands.Abstract
{
    public abstract class FinancasCommand
    {
        public decimal Valor { get; protected set; }

        public string Titulo { get; protected set; }

        public DateTime Data { get; protected set; }

        public TipoMovimentoEnum Tipo { get; protected set; }

        public Guid ClienteId { get; protected set; }
    }
}
