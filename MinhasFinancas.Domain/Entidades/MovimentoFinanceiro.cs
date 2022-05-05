using MinhasFinancas.Domain.Core.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain.Entidades
{
    public class MovimentoFinanceiro : Base
    {
        //Constructor for EFCore
        public MovimentoFinanceiro()
        {

        }

        public MovimentoFinanceiro(decimal valor, string titulo, DateTime data, int tipo, Guid clienteId)
        {
            Id = Guid.NewGuid();
            Valor = valor;
            Titulo = titulo;
            Data = data.Date;
            Tipo = tipo;
            ClienteId = clienteId;
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

        public decimal Valor { get; private set; }

        public string Titulo { get; private set; }

        public DateTime Data { get; private set; }

        public int Tipo { get; private set; }

        [ForeignKey("clienteId")]
        public Guid ClienteId { get; private set; }
    }
}
