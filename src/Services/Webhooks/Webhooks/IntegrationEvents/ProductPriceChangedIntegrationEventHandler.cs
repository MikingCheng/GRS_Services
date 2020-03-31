using System.Threading.Tasks;
using WWGRS.BuildingBlocks.EventBuses.Abstractions;

namespace WWGRS.Services.Webhooks.IntegrationEvents
{
    public class ProductPriceChangedIntegrationEventHandler : IIntegrationEventHandler<ProductPriceChangedIntegrationEvent>
    {
        public async Task Handle(ProductPriceChangedIntegrationEvent @event)
        {
            int i = 0;
        }
    }
}
