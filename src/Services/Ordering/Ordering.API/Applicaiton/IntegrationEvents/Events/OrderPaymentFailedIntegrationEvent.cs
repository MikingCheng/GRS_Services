using WWGRS.BuildingBlocks.EventBuses.Events;

namespace WWGRS.Service.Ordering.API.Applicaiton.IntegrationEvents.Events
{
    public class OrderPaymentFailedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public OrderPaymentFailedIntegrationEvent(int orderId) => OrderId = orderId;
    }
}
