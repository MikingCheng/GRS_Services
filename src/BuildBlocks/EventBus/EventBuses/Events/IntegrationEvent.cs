using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WWGRS.BuildingBlocks.EventBuses.Events
{
    public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = new Guid();
            CreateDate = DateTime.UtcNow;
        }

        [JsonConstructor]
        public IntegrationEvent(Guid id, DateTime dt)
        {
            Id = id;
            CreateDate = dt;
        }


        [JsonProperty]
        public Guid Id
        {
            get; private set;
        }

        [JsonProperty]
        public DateTime CreateDate { get; private set; }


    }
}
