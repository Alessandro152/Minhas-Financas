using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Infra.Data;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhasFinancas.Infra.Repositories
{
    public class FinancasQueryRepository : IFinancasQueryRepository
    {
        private readonly DataContext _context;

        public FinancasQueryRepository(DataContext context)
        {
            _context = context;
        }

        public async IAsyncEnumerable<MovimentoFinanceiroViewModel> GetAll(DateTime data, int tipo)
        {
            var lista = new List<UpdateMovimentoFinanceiroViewModel>();
            var result = await _context.Valores
                                       .Where(x => x.Data.ToShortDateString() == data.ToShortDateString() && (int)x.Tipo == tipo)
                                       .ToArrayAsync();

            foreach (var item in result)
            {
                yield return new MovimentoFinanceiroViewModel
                {
                    Id = item.Id,
                    Valor = item.Valor,
                    Titulo = item.Titulo,
                    Data = item.Data
                };
            }
        }

        public async IAsyncEnumerable<MovimentoFinanceiroViewModel> GetAllFinancas(Guid usuarioId)
        {
            var result = await _context.Valores
                                       .Where(x => x.ClienteId == usuarioId && x.Data.Month == DateTime.Now.Month)
                                       .ToListAsync();

            foreach (var item in result)
            {
                yield return new MovimentoFinanceiroViewModel
                {
                    Id = item.Id,
                    Valor = item.Valor,
                    Titulo = item.Titulo,
                    Data = item.Data
                };
            }
        }
    }
}
