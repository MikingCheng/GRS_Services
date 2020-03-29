using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WWGRS.Service.Ordering.Domain.AggregatesModel.OrderAggregate;

namespace WWGRS.Service.Ordering.Domain.Events
{
    public class OrderShippedDomainEvent : INotification
    {
        public Order Order { get; }

        public OrderShippedDomainEvent(Order order)
        {
            Order = order;
        }
    }
}
