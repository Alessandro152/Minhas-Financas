using FluentResults;
using MediatR;
using MinhasFinancas.Domain.Commands.Abstract;
using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.Enum;
using System;

namespace MinhasFinancas.Domain.Financas.Commands
{
    public class NewMovimentoFinanceiroCommand : FinancasCommand, IRequest<Result<Entidade>>
    {
        public NewMovimentoFinanceiroCommand(decimal valor, string titulo, DateTime data, TipoMovimentoEnum tipo, Guid clienteId)
        {
            Valor = valor;
            Titulo = titulo;
            Data = data;
            Tipo = tipo;
            ClienteId = clienteId;
        }
    }
}
