using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWGRS.BuildingBlocks.EventBuses.Abstractions;
using WWGRS.Service.Ordering.API.Applicaiton.Commands;
using WWGRS.Service.Ordering.API.Applicaiton.IntegrationEvents.Events;

namespace WWGRS.Service.Ordering.API.Applicaiton.IntegrationEvents.EventHandling
{
    public class OrderStockConfirmedIntegrationEventHandler :
        IIntegrationEventHandler<OrderStockConfirmedIntegrationEvent>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderStockConfirmedIntegrationEventHandler> _logger;

        public OrderStockConfirmedIntegrationEventHandler(
            IMediator mediator,
            ILogger<OrderStockConfirmedIntegrationEventHandler> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(OrderStockConfirmedIntegrationEvent @event)
        {
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
            {
                _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

                var command = new SetStockConfirmedOrderStatusCommand(@event.OrderId);

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    command.GetGenericTypeName(),
                    nameof(command.OrderNumber),
                    command.OrderNumber,
                    command);

                await _mediator.Send(command);
            }
        }
    }
}
