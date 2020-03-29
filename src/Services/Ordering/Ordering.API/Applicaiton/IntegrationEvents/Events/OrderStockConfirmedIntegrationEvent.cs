using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWGRS.BuildingBlocks.EventBuses.Events;

namespace WWGRS.Service.Ordering.API.Applicaiton.IntegrationEvents.Events
{
    public class OrderStockConfirmedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public OrderStockConfirmedIntegrationEvent(int orderId) => OrderId = orderId;
    }
}
