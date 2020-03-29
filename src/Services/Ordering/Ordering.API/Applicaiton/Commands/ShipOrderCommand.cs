using MediatR;
using System.Runtime.Serialization;

namespace WWGRS.Service.Ordering.API.Applicaiton.Commands
{
    public class ShipOrderCommand : IRequest<bool>
    {
        [DataMember]
        public int OrderNumber { get; private set; }

        public ShipOrderCommand(int orderNumber)
        {
            OrderNumber = orderNumber;
        }
    }
}
