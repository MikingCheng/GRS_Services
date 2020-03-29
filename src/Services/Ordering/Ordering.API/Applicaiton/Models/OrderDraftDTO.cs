using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWGRS.Service.Ordering.Domain.AggregatesModel.OrderAggregate;

namespace WWGRS.Service.Ordering.API.Applicaiton.Models
{
    public class OrderDraftDTO
    {
        public IEnumerable<OrderItemDTO> OrderItems { get; set; }
        public decimal Total { get; set; }

        public static OrderDraftDTO FromOrder(Order order)
        {
            return new OrderDraftDTO()
            {
                OrderItems = order.OrderItems.Select(oi => new OrderItemDTO
                {
                    Discount = oi.GetCurrentDiscount(),
                    ProductId = oi.ProductId,
                    UnitPrice = oi.GetUnitPrice(),
                    PictureUrl = oi.GetPictureUri(),
                    Units = oi.GetUnits(),
                    ProductName = oi.GetOrderItemProductName()
                }),
                Total = order.GetTotal()
            };
        }
    }
}
