using FluentResults;
using MediatR;
using MinhasFinancas.Domain.Commands.Abstract;
using MinhasFinancas.Domain.Core.Enums;
using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.Enum;
using System;

namespace MinhasFinancas.Domain.Financas.Commands
{
    public class NewMovimentoFinanceiroCommand : FinancasCommand, IRequest<Result<Entidade>>
    {
        public NewMovimentoFinanceiroCommand(decimal valor, 
                                             string descricao, 
                                             DateTime data, 
                                             TipoMovimentoEnum tipo,
                                             SimNaoEnum pago,
                                             SimNaoEnum recebido,
                                             int usuarioId)
        {
            Valor = valor;
            Descricao = descricao;
            DataVencimento = data;
            Tipo = tipo;
            Pago = pago;
            Recebido = recebido;
            UsuarioId = usuarioId;
        }
    }
}
