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
        public UpdateMovimentoFinanceiroCommand(int id, decimal valor, string titulo, DateTime data, TipoMovimentoEnum tipo)
        {
            Id = id;
            Valor = valor;
            Descricao = titulo;
            DataVencimento = data;
            Tipo = tipo;
        }
    }
}
