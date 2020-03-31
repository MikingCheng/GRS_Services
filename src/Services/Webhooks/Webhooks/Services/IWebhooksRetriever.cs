using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWGRS.Services.Webhooks.Models;

namespace WWGRS.Services.Webhooks.Services
{
    public interface IWebhooksRetriever
    {
        Task<IEnumerable<WebhookSubscription>> GetSubscriptionsOfType(WebhookType type);
    }
}
