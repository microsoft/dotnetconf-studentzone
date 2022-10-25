using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using WaterConsumption.Proxy.Models;

namespace WaterConsumption.Proxy.Triggers
{
    public class WaterConsumptionHttpTrigger
    {
        private readonly HttpClient _http;
        private ILogger<WaterConsumptionHttpTrigger> _logger;

        public WaterConsumptionHttpTrigger(IHttpClientFactory factory, ILogger<WaterConsumptionHttpTrigger> logger)
        {
            this._http = factory.ThrowIfNullOrDefault().CreateClient("proxy");
            this._logger = logger.ThrowIfNullOrDefault();
        }

        [FunctionName(nameof(WaterConsumptionHttpTrigger.GetWaterConsumptionData))]
        [OpenApiOperation(operationId: nameof(WaterConsumptionHttpTrigger.GetWaterConsumptionData), tags: new[] { "consumptions" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(WaterConsumptionModel), Description = "The OK response")]
        public async Task<IActionResult> GetWaterConsumptionData(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "consumptions/water")] HttpRequest req)
        {
            this._logger.LogInformation("C# HTTP trigger function processed a request.");

            var consumptions = new WaterConsumptionModel()
            {
                Data = new List<WaterConsumptionItemModel>()
                {
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T00:00:00Z"), Consumption = 100 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T00:10:00Z"), Consumption = 110 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T00:20:00Z"), Consumption = 120 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T00:30:00Z"), Consumption = 130 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T00:40:00Z"), Consumption = 140 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T00:50:00Z"), Consumption = 150 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T01:00:00Z"), Consumption = 100 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T01:10:00Z"), Consumption = 110 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T01:20:00Z"), Consumption = 120 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T01:30:00Z"), Consumption = 130 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T01:40:00Z"), Consumption = 140 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T01:50:00Z"), Consumption = 150 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T02:00:00Z"), Consumption = 100 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T02:10:00Z"), Consumption = 110 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T02:20:00Z"), Consumption = 120 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T02:30:00Z"), Consumption = 130 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T02:40:00Z"), Consumption = 140 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T02:50:00Z"), Consumption = 150 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T03:00:00Z"), Consumption = 100 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T03:10:00Z"), Consumption = 110 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T03:20:00Z"), Consumption = 120 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T03:30:00Z"), Consumption = 130 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T03:40:00Z"), Consumption = 140 },
                    new WaterConsumptionItemModel() { DateTime = DateTimeOffset.Parse("2022-10-01T03:50:00Z"), Consumption = 150 },
                }
            };

            var result = new OkObjectResult(consumptions);

            return await Task.FromResult(result).ConfigureAwait(false);
        }
    }
}
