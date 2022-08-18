using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using WebPanel.Models;

namespace WebPanel.Controllers
{
    public class CurrencyController : Controller
    {
        public static List<Currency> Get(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("http://10.0.60.46:5223/api/Currencies", Method.Get);
            var response = client.Execute(request);
            List<Currency> CurrencyList = JsonConvert.DeserializeObject<List<Currency>>(response.Content);




            return CurrencyList;
        }



        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var client = new RestClient();
            var request = new RestRequest("http://10.0.60.46:5223/api/Currencies", Method.Get);
            var response = client.Execute(request);
            List<Currency> CurrencyList = JsonConvert.DeserializeObject<List<Currency>>(response.Content);



            return DataSourceLoader.Load(CurrencyList, loadOptions);
        }



    }
}
