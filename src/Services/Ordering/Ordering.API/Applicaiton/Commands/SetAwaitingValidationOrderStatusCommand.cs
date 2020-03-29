using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WWGRS.Service.Ordering.API.Applicaiton.Commands
{
    public class SetAwaitingValidationOrderStatusCommand : IRequest<bool>
    {
        [DataMember]
        public int OrderNumber { get; private set; }

        public SetAwaitingValidationOrderStatusCommand(int orderNumber)
        {
            OrderNumber = orderNumber;
        }
    }
}
