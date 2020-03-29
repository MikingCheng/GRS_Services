using WWGRS.BuildingBlocks.EventBuses.Events;

namespace WWGRS.Services.OrderingrHub.IntegrationEvents.Events
{
    public class OrderStatusChangedToPaidIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }
        public string OrderStatus { get; }
        public string BuyerName { get; }

        public OrderStatusChangedToPaidIntegrationEvent(int orderId,
            string orderStatus, string buyerName)
        {
            OrderId = orderId;
            OrderStatus = orderStatus;
            BuyerName = buyerName;
        }
    }
}
