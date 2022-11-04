using MyWaterConsumption.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyWaterConsumption
{
    public class APIManager
    {
        static readonly string BaseAddress = "https://chris-water3.azurewebsites.net";
        static readonly string Url = $"{BaseAddress}/consumption/";
        private static string authorizationKey = "iSdRdw1aNjAFWcX-2GVQmR533bbx8gc8XWS1OnBkcKZ_AzFuudr7kw==";
        static HttpClient client;

        public static async Task<IEnumerable<Consumption>> GetAll()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("dotnetconfstudentzone", authorizationKey);

            var response = await client.GetStringAsync($"{Url}");

            return JsonConvert.DeserializeObject<List<Consumption>>(response);
        }

        public static async Task<Consumption> Add(int id, int consumption, DateTime dateTime)
        {
            Consumption consumption1 = new Consumption()
            {
                id = id,
                consumption = consumption,
                dateTime = dateTime
            };

            var msg = new HttpRequestMessage(HttpMethod.Post, $"{Url}");

            msg.Headers.Add("Accept", "application/json");
            msg.Headers.Add("dotnetconfstudentzone", authorizationKey);

            msg.Content = JsonContent.Create<Consumption>(consumption1);

            var response = await client.SendAsync(msg);
            response.EnsureSuccessStatusCode();

            var returnedJson = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Consumption>(returnedJson);
        }
    }
}
