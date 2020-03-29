using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WWGRS.Service.Ordering.API.Applicaiton.Models;
using WWGRS.Service.Ordering.API.Extensions;
using WWGRS.Service.Ordering.API.Infrastructure.Services;
using WWGRS.Service.Ordering.Domain.AggregatesModel.OrderAggregate;

namespace WWGRS.Service.Ordering.API.Applicaiton.Commands
{
    // Regular CommandHandler
    public class CreateOrderDraftCommandHandler
       : IRequestHandler<CreateOrderDraftCommand, OrderDraftDTO>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IIdentityService _identityService;
        private readonly IMediator _mediator;

        // Using DI to inject infrastructure persistence Repositories
        public CreateOrderDraftCommandHandler(IMediator mediator, IIdentityService identityService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public Task<OrderDraftDTO> Handle(CreateOrderDraftCommand message, CancellationToken cancellationToken)
        {

            var order = Order.NewDraft();
            var orderItems = message.Items.Select(i => i.ToOrderItemDTO());
            foreach (var item in orderItems)
            {
                order.AddOrderItem(item.ProductId, item.ProductName, item.UnitPrice, item.Discount, item.PictureUrl, item.Units);
            }

            return Task.FromResult(OrderDraftDTO.FromOrder(order));
        }
    }
}
