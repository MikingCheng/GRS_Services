using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WWGRS.Service.Ordering.Domain.AggregatesModel.OrderAggregate;

namespace WWGRS.Service.Ordering.Domain.Events
{
    public class OrderStatusChangedToPaidDomainEvent
        : INotification
    {
        public int OrderId { get; }
        public IEnumerable<OrderItem> OrderItems { get; }

        public OrderStatusChangedToPaidDomainEvent(int orderId,
            IEnumerable<OrderItem> orderItems)
        {
            OrderId = orderId;
            OrderItems = orderItems;
        }

    }
}
