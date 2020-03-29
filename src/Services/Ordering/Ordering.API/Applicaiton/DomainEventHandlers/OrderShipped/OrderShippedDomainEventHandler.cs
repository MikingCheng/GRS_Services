﻿using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WWGRS.Service.Ordering.API.Applicaiton.IntegrationEvents;
using WWGRS.Service.Ordering.API.Applicaiton.IntegrationEvents.Events;
using WWGRS.Service.Ordering.Domain.AggregatesModel.BuyerAggregate;
using WWGRS.Service.Ordering.Domain.AggregatesModel.OrderAggregate;
using WWGRS.Service.Ordering.Domain.Events;

namespace WWGRS.Service.Ordering.API.Applicaiton.DomainEventHandlers.OrderShipped
{
    public class OrderShippedDomainEventHandler
        : INotificationHandler<OrderShippedDomainEvent>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBuyerRepository _buyerRepository;
        private readonly IOrderingIntegrationEventService _orderingIntegrationEventService;
        private readonly ILoggerFactory _logger;

        public OrderShippedDomainEventHandler(
            IOrderRepository orderRepository,
            ILoggerFactory logger,
            IBuyerRepository buyerRepository,
            IOrderingIntegrationEventService orderingIntegrationEventService)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _buyerRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
            _orderingIntegrationEventService = orderingIntegrationEventService;
        }

        public async Task Handle(OrderShippedDomainEvent orderShippedDomainEvent, CancellationToken cancellationToken)
        {
            _logger.CreateLogger<OrderShippedDomainEvent>()
                .LogTrace("Order with Id: {OrderId} has been successfully updated to status {Status} ({Id})",
                    orderShippedDomainEvent.Order.Id, nameof(OrderStatus.Shipped), OrderStatus.Shipped.Id);

            var order = await _orderRepository.GetAsync(orderShippedDomainEvent.Order.Id);
            var buyer = await _buyerRepository.FindByIdAsync(order.GetBuyerId.Value.ToString());

            var orderStatusChangedToShippedIntegrationEvent = new OrderStatusChangedToShippedIntegrationEvent(order.Id, order.OrderStatus.Name, buyer.Name);
            await _orderingIntegrationEventService.AddAndSaveEventAsync(orderStatusChangedToShippedIntegrationEvent);
        }
    }
}
