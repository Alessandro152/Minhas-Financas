using System.Collections.Generic;

namespace MinhasFinancas.Domain.Core.Shared
{
    public class Result
    {
        public List<string> ErrorMessage { get; set; }

        public bool HasError { get; set; }
    }
}
