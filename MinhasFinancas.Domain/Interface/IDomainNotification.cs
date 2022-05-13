using System.Collections.Generic;

namespace MinhasFinancas.Domain.Interface
{
    public interface IDomainNotification
    {
        public List<string> Message { get; }

        public bool HasError { get; }

        void AddMessage(string message);
    }
}
