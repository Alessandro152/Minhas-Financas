using MinhasFinancas.Domain.Core.Shared;
using System;

namespace MinhasFinancas.Domain.Entidades
{
    public class MovimentoFinanceiro : Entidade
    {
        protected MovimentoFinanceiro()
        {

        }

        public MovimentoFinanceiro(Guid id, decimal valor, string titulo, DateTime data, int tipo, Guid clienteId)
        {
            Id = id;
            Valor = valor;
            Titulo = titulo;
            Data = data.Date;
            Tipo = tipo;
            ClienteId = clienteId;
        }

        public decimal Valor { get; }

        public string Titulo { get; }

        public DateTime Data { get; }

        public int Tipo { get; }

        public Guid ClienteId { get; }
    }
}
