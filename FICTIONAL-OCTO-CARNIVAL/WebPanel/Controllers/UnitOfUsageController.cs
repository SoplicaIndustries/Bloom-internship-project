using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using WebPanel.Models;

namespace WebPanel.Controllers
{
    public class UnitOfUsageController : Controller
    {


        public object Get(DataSourceLoadOptions loadOptions)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5223/api/UnitsOfUsages", Method.Get);
            var response = client.Execute(request);
            IEnumerable<UnitsOfUsage> UnitsList = JsonConvert.DeserializeObject<IEnumerable<UnitsOfUsage>>(response.Content);




            return DataSourceLoader.Load(UnitsList, loadOptions);
        }



        public static List<UnitsOfUsage> GetUnits()
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5223/api/UnitsOfUsages", Method.Get);
            var response = client.Execute(request);
            List<UnitsOfUsage> UnitsList = JsonConvert.DeserializeObject<List<UnitsOfUsage>>(response.Content);




            return UnitsList;
        }


    }
}
