using System;

namespace MinhasFinancas.Domain.Commands.Abstract
{
    public abstract class UsuarioCommand
    {
        public int UsuarioId { get; protected set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public string Senha { get; protected set; }
    }
}
