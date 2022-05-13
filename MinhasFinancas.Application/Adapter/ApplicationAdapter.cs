using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.QueryStack.ViewModel;

namespace MinhasFinancas.Application.Adapter
{
    public class ApplicationAdapter : IApplicationAdapter
    {
        public ApplicationAdapter()
        {

        }

        public ResultViewModel RetornarDomainResult(dynamic result)
        {
            return new ResultViewModel
            {
                ErrorMessage = result.ErrorMessage,
                HasError = result.HasError
            };
        }
    }
}
