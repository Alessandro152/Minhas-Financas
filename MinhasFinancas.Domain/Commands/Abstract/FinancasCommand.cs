using MinhasFinancas.Domain.Enum;
using System;

namespace MinhasFinancas.Domain.Commands.Abstract
{
    public abstract class FinancasCommand
    {
        public int Id { get; protected set; }
        public decimal Valor { get; protected set; }
        public string Descricao { get; protected set; }
        public DateTime Data { get; protected set; }
        public TipoMovimentoEnum Tipo { get; protected set; }
        public int UsuarioId { get; protected set; }
    }
}
