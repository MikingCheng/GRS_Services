using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WWGRS.Service.Ordering.API.Applicaiton.Commands
{
    public class CancelOrderCommand : IRequest<bool>
    {
        [DataMember]
        public int OrderNumber { get; private set; }
        public CancelOrderCommand()
        {

        }
        public CancelOrderCommand(int orderNumber)
        {
            OrderNumber = orderNumber;
        }
    }
}
