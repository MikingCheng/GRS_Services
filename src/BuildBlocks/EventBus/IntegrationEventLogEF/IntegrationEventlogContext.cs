using System;
using Microsoft.EntityFrameworkCore;

namespace WWGRS.Services.BuildingBlocks.IntegrationEventLogEF
{
    public class IntegrationEventlogContext: DbContext
    {
        public IntegrationEventlogContext(DbContextOptions<IntegrationEventlogContext> options)
            : base(options)
        {
        }

        public DbSet<IntegrationEventlogContext>
    }
}
