using System.Collections.Generic;

namespace MinhasFinancas.Application.QueryStack.ViewModel
{
    public class ResultViewModel
    {
        public List<string> ErrorMessage { get; set; }

        public bool HasError { get; set; }
    }
}
