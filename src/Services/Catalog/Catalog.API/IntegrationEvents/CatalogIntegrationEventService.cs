﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WWGRS.BuildingBlocks.EventBuses;
using WWGRS.BuildingBlocks.IntegrationEventLogEF.Services;
using WWGRS.Services.Catalog.API.Infrastructure;
using WWGRS.BuildingBlocks.EventBuses.Abstractions;
using Microsoft.Extensions.Logging;
using WWGRS.BuildingBlocks.EventBuses.Events;
using IntegrationEventLogEF.Utilities;

namespace WWGRS.Services.Catalog.API.IntegrationEvents
{
    public class CatalogIntegrationEventService : ICatalogIntegrationEventService
    {
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventlogServiceFactory;
        private readonly IEventBus _eventBus;
        private readonly CatalogContext _catalogContext;
        private readonly IIntegrationEventLogService _eventLogService;
        private readonly ILogger<CatalogIntegrationEventService> _logger;

        public CatalogIntegrationEventService(
            ILogger<CatalogIntegrationEventService> logger,
            IEventBus eventBus,
            CatalogContext catalogContext,
            Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
            _integrationEventlogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _eventLogService = _integrationEventlogServiceFactory(_catalogContext.Database.GetDbConnection());
        }

        public async Task SaveEventAndCatalogContextChangesAsync(IntegrationEvent evt)
        {
            _logger.LogInformation("----- CatalogIntegrationEventService - Saving changes and integrationEvent: {IntegrationEventId}", evt.Id);

            //Use of an EF Core resiliency strategy when using multiple DbContexts within an explicit BeginTransaction():
            //See: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency            
            await ResilientTransaction.New(_catalogContext).ExecuteAsync(async () =>
            {
                // Achieving atomicity between original catalog database operation and the IntegrationEventLog thanks to a local transaction
                await _catalogContext.SaveChangesAsync();
                await _eventLogService.SaveEventAsync(evt, _catalogContext.Database.CurrentTransaction);
            });
        }
        public async Task PublishThroughEventBusAsync(IntegrationEvent evt)
        {
           try
            {
                _logger.LogInformation("----- Publishing integration event: {IntegrationEventId_published} from {AppName} - ({@IntegrationEvent})", evt.Id, Program.AppName, evt);

                await _eventLogService.MarkEventAsInProgressAsync(evt.Id);
                _eventBus.Publish(evt);
                await _eventLogService.MarkEventAsPublishedAsync(evt.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR Publishing integration event: {IntegrationEventId} from {AppName} - ({@IntegrationEvent})", evt.Id, Program.AppName, evt);
                await _eventLogService.MarkEventAsFailedAsync(evt.Id);
            }
        }
    }
}
