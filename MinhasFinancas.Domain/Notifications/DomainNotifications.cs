using MinhasFinancas.Domain.Interface;
using System.Collections.Generic;

namespace MinhasFinancas.Domain.Notifications
{
    public class DomainNotifications : IDomainNotification
    {
        public DomainNotifications()
        {
            Message = new List<string>();
        }

        public List<string> Message { get; }

        public bool HasError => Message.Count == 0;

        public void AddMessage(string message)
        {
            Message.Add(message);
        }
    }
}
