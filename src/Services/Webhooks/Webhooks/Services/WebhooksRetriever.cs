using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWGRS.Services.Webhooks.Infrastructure;
using WWGRS.Services.Webhooks.Models;

namespace WWGRS.Services.Webhooks.Services
{
    public class WebhooksRetriever : IWebhooksRetriever
    {
        private readonly WebhooksContext _db;
        public WebhooksRetriever(WebhooksContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<WebhookSubscription>> GetSubscriptionsOfType(WebhookType type)
        {
            var data = await _db.Subscriptions.Where(s => s.Type == type).ToListAsync();
            return data;
        }
    }
}
