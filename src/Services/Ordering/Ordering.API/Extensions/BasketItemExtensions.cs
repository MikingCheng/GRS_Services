using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWGRS.Service.Ordering.API.Applicaiton.Models;
using static WWGRS.Service.Ordering.API.Applicaiton.Commands.CreateOrderCommand;

namespace WWGRS.Service.Ordering.API.Extensions
{
    public static class BasketItemExtensions
    {
        public static IEnumerable<OrderItemDTO> ToOrderItemsDTO(this IEnumerable<BasketItem> basketItems)
        {
            foreach (var item in basketItems)
            {
                yield return item.ToOrderItemDTO();
            }
        }

        public static OrderItemDTO ToOrderItemDTO(this BasketItem item)
        {
            return new OrderItemDTO()
            {
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                PictureUrl = item.PictureUrl,
                UnitPrice = item.UnitPrice,
                Units = item.Quantity
            };
        }
    }
}
