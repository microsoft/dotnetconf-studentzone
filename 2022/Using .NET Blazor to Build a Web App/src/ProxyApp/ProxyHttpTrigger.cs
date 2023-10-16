using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using ProxyApp.Proxies;

namespace ProxyApp
{
    public class ProxyHttpTrigger
    {
        private readonly ProxyClient _proxy;
        private readonly ILogger<ProxyHttpTrigger> _logger;

        public ProxyHttpTrigger(ProxyClient proxy, ILogger<ProxyHttpTrigger> logger)
        {
            this._proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [FunctionName(nameof(ProxyHttpTrigger.GetWaterConsumptionData))]
        public async Task<IActionResult> GetWaterConsumptionData(
            [HttpTrigger(AuthorizationLevel.Function, "GET", Route = "consumptions/water")] HttpRequest req)
        {
            this._logger.LogInformation("C# HTTP trigger function processed a request.");

            var result = await this._proxy.GetWaterConsumptionDataAsync(start: null, days: null);

            return new OkObjectResult(result);
        }
    }
}
