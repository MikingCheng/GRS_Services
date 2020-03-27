﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WWGRS.Service.Ordering.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
