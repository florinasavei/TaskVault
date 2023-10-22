using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskVault.Infrastructure.Services
{
    public interface IMyHttpClientService
    {
        Task<string> GetApiResponseAsync(string apiUrl);
    }
}
