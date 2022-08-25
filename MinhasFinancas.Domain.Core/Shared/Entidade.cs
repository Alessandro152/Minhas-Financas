using System;

namespace MinhasFinancas.Domain.Core.Shared
{
    public abstract class Entidade
    {
        public Guid Id { get; protected set; }
    }
}
