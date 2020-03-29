using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWGRS.Service.Ordering.Domain.AggregatesModel.OrderAggregate;

namespace WWGRS.Service.Ordering.API.Applicaiton.Queries
{
    public interface IOrderQueries
    {
        Task<Order> GetOrderAsync(int id);

        Task<IEnumerable<OrderSummary>> GetOrdersFromUserAsync(Guid userId);

        Task<IEnumerable<CardType>> GetCardTypesAsync();
    }
}
