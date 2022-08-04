using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.ViewModel;
using MinhasFinancas.Infra.Data;
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

        public Task<bool> ExcluirMovimento(IEnumerable<Guid> id)
        {
            try
            {
                foreach (var item in id)
                {
                    var result = _context.Valores.Where(x => x.Id == item).FirstOrDefault();

                    if (result != null)
                    {
                        _context.Valores.Remove(result);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Task.FromResult(true);
        }

        public async Task<bool> ExcluirMovimento(DateTime data)
        {
            try
            {
                var result = _context.Valores.Where(x => x.Data.ToShortDateString() == data.ToShortDateString()).AsEnumerable();

                if (result.Any())
                {
                    foreach (var item in result)
                    {
                        _context.Valores.Remove(item);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        public async Task<IEnumerable<MovimentoFinanceiroViewModel>> GetAll(DateTime data, int tipo)
        {
            var lista = new List<MovimentoFinanceiroViewModel>();
            try
            {
                var result = _context.Valores.Where(x => (x.Data.ToShortDateString() == data.ToShortDateString()) && (x.Tipo == tipo)).AsEnumerable();

                if (result.Any())
                {
                    foreach (var item in result)
                    {
                        lista.Add(new MovimentoFinanceiroViewModel
                        {
                            Id = item.Id,
                            Valor = item.Valor,
                            Titulo = item.Titulo,
                            Data = item.Data
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }
    }
}
