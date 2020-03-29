using MediatR;
using System.Runtime.Serialization;

namespace WWGRS.Service.Ordering.API.Applicaiton.Commands
{
    public class SetPaidOrderStatusCommand : IRequest<bool>
    {
        [DataMember]
        public int OrderNumber { get; private set; }

        public SetPaidOrderStatusCommand(int orderNumber)
        {
            OrderNumber = orderNumber;
        }
    }
}
