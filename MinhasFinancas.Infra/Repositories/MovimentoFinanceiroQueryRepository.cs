using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Infra.Data;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Infra.Repositories
{
    public class MovimentoFinanceiroQueryRepository : IMovimentoFinanceiroQueryRepository
    {
        private readonly DataContext _context;

        public MovimentoFinanceiroQueryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> ExcluirMovimento(IEnumerable<Guid> id)
        {
            foreach (var item in id)
            {
                var result = await _context.Valores.Where(x => x.Id == item).FirstOrDefaultAsync();

                if (result != null)
                {
                    _context.Valores.Remove(result);
                }
            }

            return true;
        }

        public async Task<bool> ExcluirMovimento(DateTime data)
        {

            var result = _context.Valores.Where(x => x.Data.ToShortDateString() == data.ToShortDateString()).AsEnumerable();

            if (result.Any())
            {
                foreach (var item in result)
                {
                    _context.Valores.Remove(item);
                }
            }

            return true;
        }

        public async Task<IEnumerable<UpdateMovimentoFinanceiroViewModel>> GetAll(DateTime data, int tipo)
        {
            var lista = new List<UpdateMovimentoFinanceiroViewModel>();
            var result = await _context.Valores.Where(x => (x.Data.ToShortDateString() == data.ToShortDateString()) && ((int)x.Tipo == tipo)).ToArrayAsync();

            if (result.Any())
            {
                foreach (var item in result)
                {
                    lista.Add(new UpdateMovimentoFinanceiroViewModel
                    {
                        Id = item.Id,
                        Valor = item.Valor,
                        Titulo = item.Titulo,
                        Data = item.Data
                    });
                }
            }

            return lista;
        }

        Task<IEnumerable<MovimentoFinanceiroViewModel>> IMovimentoFinanceiroQueryRepository.GetAll(DateTime data, int tipo)
        {
            throw new NotImplementedException();
        }
    }
}
