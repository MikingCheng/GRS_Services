using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WWGRS.Service.Ordering.Domain.SeedWork;

namespace WWGRS.Service.Ordering.Domain.AggregatesModel.OrderAggregate
{
    //This is just the RepositoryContracts or Interface defined at the Domain Layer
    //as requisite for the Order Aggregate

    public interface IOrderRepository: IRepository<Order>
    {
        Order Add(Order order);

        void Update(Order order);

        Task<Order> GetAsync(int orderId);
    }
}
