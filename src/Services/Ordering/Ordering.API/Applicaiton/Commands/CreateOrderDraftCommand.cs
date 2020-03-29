using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWGRS.Service.Ordering.API.Applicaiton.Models;

namespace WWGRS.Service.Ordering.API.Applicaiton.Commands
{
    public class CreateOrderDraftCommand : IRequest<OrderDraftDTO>
    {

        public string BuyerId { get; private set; }

        public IEnumerable<BasketItem> Items { get; private set; }

        public CreateOrderDraftCommand(string buyerId, IEnumerable<BasketItem> items)
        {
            BuyerId = buyerId;
            Items = items;
        }
    }
}
