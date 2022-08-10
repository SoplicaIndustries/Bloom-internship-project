using WebPanel.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace WebPanel.Controllers
{
    public class InvoicesController : Controller
    {
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5223/api/Invoices", Method.Get);
            var response = client.Execute(request);
            List<Invoices> InvoiceList = JsonConvert.DeserializeObject<List<Invoices>>(response.Content);



            return DataSourceLoader.Load(InvoiceList, loadOptions);
        }
    }
}
