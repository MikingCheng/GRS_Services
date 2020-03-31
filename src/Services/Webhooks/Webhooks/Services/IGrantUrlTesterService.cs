using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WWGRS.Services.Webhooks.Services
{
    public interface IGrantUrlTesterService
    {
        Task<bool> TestGrantUrl(string urlHook, string url, string token);
    }
}
