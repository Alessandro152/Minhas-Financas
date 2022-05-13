using MinhasFinancas.Application.QueryStack.ViewModel;

namespace MinhasFinancas.Application.Interface
{
    public interface IApplicationAdapter
    {
        ResultViewModel RetornarDomainResult(dynamic result);
    }
}
