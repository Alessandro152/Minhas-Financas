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
        public NewMovimentoFinanceiroCommand(decimal valor, string descricao, DateTime data, TipoMovimentoEnum tipo, int usuarioId)
        {
            Valor = valor;
            Descricao = descricao;
            Data = data;
            Tipo = tipo;
            UsuarioId = usuarioId;
        }
    }
}
