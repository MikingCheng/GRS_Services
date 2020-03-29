using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWGRS.BuildingBlocks.EventBuses.Events;

namespace WWGRS.Service.Ordering.API.Applicaiton.IntegrationEvents.Events
{
    public class OrderPaymentSucceededIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public OrderPaymentSucceededIntegrationEvent(int orderId) => OrderId = orderId;
    }
}
