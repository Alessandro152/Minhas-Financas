using FluentResults;
using MediatR;
using MinhasFinancas.Domain.Commands.Abstract;
using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.Enum;
using System;

namespace MinhasFinancas.Domain.Financas.Commands
{
    public class UpdateMovimentoFinanceiroCommand : FinancasCommand, IRequest<Result<Entidade>>
    {
        public UpdateMovimentoFinanceiroCommand(Guid id, decimal valor, string titulo, DateTime data, TipoFinanceiroEnum tipo, Guid clienteId)
        {
            Id = id;
            Valor = valor;
            Titulo = titulo;
            Data = data;
            Tipo = tipo;
            ClienteId = clienteId;
        }

        public Guid Id { get; }
    }
}
