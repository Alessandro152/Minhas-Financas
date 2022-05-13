using MinhasFinancas.Domain.Interface;
using System.Collections.Generic;

namespace MinhasFinancas.Domain.Notifications
{
    public class DomainNotifications : IDomainNotification
    {
        public DomainNotifications()
        {

        }

        public List<string> Notifications { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public List<string> AddNotification()
        {
            return new List<string>
            {

            };
        }
    }
}
