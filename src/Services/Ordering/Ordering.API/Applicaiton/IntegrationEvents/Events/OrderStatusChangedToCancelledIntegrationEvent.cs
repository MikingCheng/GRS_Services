﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWGRS.BuildingBlocks.EventBuses.Events;

namespace WWGRS.Service.Ordering.API.Applicaiton.IntegrationEvents.Events
{
    public class OrderStatusChangedToCancelledIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }
        public string OrderStatus { get; }
        public string BuyerName { get; }

        public OrderStatusChangedToCancelledIntegrationEvent(int orderId, string orderStatus, string buyerName)
        {
            OrderId = orderId;
            OrderStatus = orderStatus;
            BuyerName = buyerName;
        }
    }
}
