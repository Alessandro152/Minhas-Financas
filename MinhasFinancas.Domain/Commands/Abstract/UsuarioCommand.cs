﻿using System;

namespace MinhasFinancas.Domain.Commands.Abstract
{
    public abstract class UsuarioCommand
    {
        public Guid UsuarioId { get; protected set; }

        public string Nome { get; protected set; }

        public string Email { get; protected set; }
    }
}