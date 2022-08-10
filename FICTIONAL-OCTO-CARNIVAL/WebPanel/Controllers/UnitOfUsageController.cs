using WebPanel.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace WebPanel.Controllers
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

        [HttpGet]
        public static object Get2(DataSourceLoadOptions loadOptions)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5223/api/UnitsOfUsages", Method.Get);
            var response = client.Execute(request);
            List<UnitsOfUsage> UnitsList = JsonConvert.DeserializeObject<List<UnitsOfUsage>>(response.Content);




            return DataSourceLoader.Load(UnitsList, loadOptions);
        }
    }
}
