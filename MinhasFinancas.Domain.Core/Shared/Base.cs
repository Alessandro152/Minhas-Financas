using System;
using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.Domain.Core.Shared
{
    public abstract class Base
    {
        [Key]
        public Guid Id { get; set; }
    }
}
