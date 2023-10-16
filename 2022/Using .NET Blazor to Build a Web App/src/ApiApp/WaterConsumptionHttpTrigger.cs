using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using ApiApp.Models;

namespace ApiApp
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
        [OpenApiSecurity(schemeName: "function_key", schemeType: SecuritySchemeType.ApiKey, Name = "x-functions-key", In = OpenApiSecurityLocationType.Header, Description = "API auth key through request header")]
        [OpenApiParameter(name: "start", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "The starting date to get the water consumption data for.")]
        [OpenApiParameter(name: "days", In = ParameterLocation.Query, Required = false, Type = typeof(int), Description = "The number of days to get the water consumption data for.")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(WaterConsumptionModel), Description = "The OK response")]
        public async Task<IActionResult> GetWaterConsumptionData(
            [HttpTrigger(AuthorizationLevel.Function, "GET", Route = "consumptions/water")] HttpRequest req)
        {
            this._logger.LogInformation("C# HTTP trigger function processed a request.");

            var start = req.Query["start"];
            if (string.IsNullOrWhiteSpace(start))
            {
                start = DateTimeOffset.Parse($"{DateTimeOffset.UtcNow.Year}-01-01").ToString("yyyy-MM-dd");
            }
            var days = req.Query["days"];
            if (string.IsNullOrWhiteSpace(days))
            {
                days = (DateTimeOffset.UtcNow.DayOfYear - DateTimeOffset.Parse(start).DayOfYear).ToString();
            }

            var seedingDateTime = DateTimeOffset.Parse(start);
            var seedingValue = 100;
            var random = new Random();
            var seedings = Enumerable.Range(0, Convert.ToInt32(days))
                        .Select(i => new WaterConsumptionItemModel
                        {
                            Date = seedingDateTime.AddDays(i),
                            Value = seedingValue + random.Next(-20, 20)
                        })
                        .ToList();

            var result = new WaterConsumptionModel()
            {
                Data = seedings
            };

            var res = new OkObjectResult(result);

            return await Task.FromResult(res).ConfigureAwait(false);
        }
    }
}
