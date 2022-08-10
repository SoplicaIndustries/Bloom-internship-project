using DbAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace Billing_Service.Controllers
{
    public class UnitOfUsageController : Controller
    {
        public static List<UnitsOfUsage> Get()
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5223/api/UnitsOfUsages", Method.Get);
            var response = client.Execute(request);
          List<UnitsOfUsage> UnitsList = JsonConvert.DeserializeObject<List<UnitsOfUsage>>(response.Content);




            return UnitsList;
        }
    }
}
