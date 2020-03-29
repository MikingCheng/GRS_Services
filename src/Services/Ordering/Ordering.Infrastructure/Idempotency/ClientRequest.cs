using System;
using System.Collections.Generic;
using System.Text;

namespace WWGRS.Service.Ordering.Infrastructure.Idempotency
{
    public class ClientRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
    }
}
