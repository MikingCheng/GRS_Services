using Newtonsoft.Json;
using System;

namespace WWGRS.Services.Webhooks.Models
{
    public class WebhookData
    {
        public DateTime When { get; }

        public string Payload { get; }

        public string Type { get; }

        public WebhookData(WebhookType hookType, object data)
        {
            When = DateTime.UtcNow;
            Type = hookType.ToString();
            Payload = JsonConvert.SerializeObject(data);
        }

    }
}
