using System.Collections.Generic;
using System.Threading.Tasks;
using WWGRS.Services.Webhooks.Models;

namespace WWGRS.Services.Webhooks.Services
{
    public interface IWebhooksSender
    {
        Task SendAll(IEnumerable<WebhookSubscription> receivers, WebhookData data);
    }
}
