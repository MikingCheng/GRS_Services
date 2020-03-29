using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WWGRS.Service.Ordering.Domain.AggregatesModel.OrderAggregate;
using WWGRS.Service.Ordering.Domain.Events;

namespace WWGRS.Service.Ordering.API.Applicaiton.DomainEventHandlers.BuyerAndPaymentMethodVerified
{
    public class UpdateOrderWhenBuyerAndPaymentMethodVerifiedDomainEventHandler
        : INotificationHandler<BuyerAndPaymentMethodVerifiedDomainEvent>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILoggerFactory _logger;

        public UpdateOrderWhenBuyerAndPaymentMethodVerifiedDomainEventHandler(
            IOrderRepository orderRepository, ILoggerFactory logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Domain Logic comment:
        // When the Buyer and Buyer's payment method have been created or verified that they existed, 
        // then we can update the original Order with the BuyerId and PaymentId (foreign keys)
        public async Task Handle(BuyerAndPaymentMethodVerifiedDomainEvent buyerPaymentMethodVerifiedEvent, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetAsync(buyerPaymentMethodVerifiedEvent.OrderId);
            orderToUpdate.SetBuyerId(buyerPaymentMethodVerifiedEvent.Buyer.Id);
            orderToUpdate.SetPaymentId(buyerPaymentMethodVerifiedEvent.Payment.Id);

            _logger.CreateLogger<UpdateOrderWhenBuyerAndPaymentMethodVerifiedDomainEventHandler>()
                .LogTrace("Order with Id: {OrderId} has been successfully updated with a payment method {PaymentMethod} ({Id})",
                    buyerPaymentMethodVerifiedEvent.OrderId, nameof(buyerPaymentMethodVerifiedEvent.Payment), buyerPaymentMethodVerifiedEvent.Payment.Id);
        }
    }
}
