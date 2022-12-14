using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using WebPanel.Models;

namespace WebPanel.Controllers
{
    public class InvoicesController : Controller
    {
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var client = new RestClient();
            var request = new RestRequest("http://10.0.60.46:5223/api/Invoices", Method.Get);
            var response = client.Execute(request);
            List<Invoices> InvoiceList = JsonConvert.DeserializeObject<List<Invoices>>(response.Content);

            Guid guid = new Guid("3fa85f62-5717-4562-b3fc-2c963f66afa6");
            List<Invoices> Klar = InvoiceList.FindAll(c => c.Customer_Id == guid);

            return DataSourceLoader.Load(Klar, loadOptions);
        }

        [HttpGet]
        public object GetInvoicesById(Guid Id, DataSourceLoadOptions options)
        {
            var client = new RestClient();
            var request = new RestRequest("http://10.0.60.46:5223/api/Invoices", Method.Get);
            var response = client.Execute(request);
            List<Invoices> InvoiceList = JsonConvert.DeserializeObject<List<Invoices>>(response.Content);
            List<Invoices> filteredList = InvoiceList.FindAll(c => c.Customer_Id == Id);
            return DataSourceLoader.Load(filteredList, options);
        }

        public FileResult GetFile(int id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://10.0.60.46:5223/api/InvoiceGenerator/{id}"),

            };


            var response = client.Send(request);
            var result = response.Content.ReadAsStringAsync().Result.Replace("\"", string.Empty); ;
            byte[] btarr = Convert.FromBase64String(result);

            return File(btarr, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName("Fakturka.pdf"));

        }
    }
}