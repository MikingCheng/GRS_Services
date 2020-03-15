using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WWGRS.BuildingBlocks.EventBuses.Events;

namespace WWGRS.BuildingBlocks.EventBuses.Abstractions
{
    public interface IIntegrationEventHandler
    {
    }
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent : IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }
}
