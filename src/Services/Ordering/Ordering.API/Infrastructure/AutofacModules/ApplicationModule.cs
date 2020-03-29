using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WWGRS.BuildingBlocks.EventBuses.Abstractions;
using WWGRS.Service.Ordering.API.Applicaiton.Commands;
using WWGRS.Service.Ordering.API.Applicaiton.Queries;
using WWGRS.Service.Ordering.Domain.AggregatesModel.BuyerAggregate;
using WWGRS.Service.Ordering.Domain.AggregatesModel.OrderAggregate;
using WWGRS.Service.Ordering.Infrastructure.Idempotency;
using WWGRS.Service.Ordering.Infrastructure.Repositories;

namespace WWGRS.Service.Ordering.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(c => new OrderQueries(QueriesConnectionString))
                .As<IOrderQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BuyerRepository>()
                .As<IBuyerRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RequestManager>()
               .As<IRequestManager>()
               .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CreateOrderCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));
        }
    }
}
