using System;
using System.Collections.Generic;
using System.Text;
using WWGRS.BuildingBlocks.EventBuses.Events;

namespace WWGRS.Service.Ordering.BackgroundTasks.Events
{
    public class GracePeriodConfirmedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public GracePeriodConfirmedIntegrationEvent(int orderId) =>
            OrderId = orderId;
    }
}
