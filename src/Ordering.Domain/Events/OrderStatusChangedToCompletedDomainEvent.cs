using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Events
{
    public class OrderStatusChangedToCompletedDomainEvent : INotification
    {
        public int OrderId { get; }

        public OrderStatusChangedToCompletedDomainEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}
