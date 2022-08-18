using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using WebPanel.Models;
namespace WebPanel.Controllers
{
    public class CustomerController : Controller
    {

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var client = new RestClient();
            var request = new RestRequest("http://10.0.60.46:5223/api/Customers", Method.Get);
            var response = client.Execute(request);
            List<Customers> CustomerList = JsonConvert.DeserializeObject<List<Customers>>(response.Content);

            foreach (Customers customer in CustomerList)
            {
                decimal Balance = GetBalance(customer.Id);
                customer.Balance = Balance;
            }


            return DataSourceLoader.Load(CustomerList, loadOptions);
        }


        public static void Post(int Deposit)
        {
            var client = new RestClient();
            var request = new RestRequest("http://10.0.60.46:5223/api/Currencies", Method.Post);

            string ToSend = JsonConvert.SerializeObject(Deposit);

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", ToSend, ParameterType.RequestBody);
            var response = client.Execute(request);


        }

        public static decimal GetBalance(Guid GUID)
        {
            var client = new RestClient();
            var request = new RestRequest($"http://10.0.60.46:5223/api/Foreign/{GUID}", Method.Get);
            var response = client.Execute(request);
            decimal Balance = JsonConvert.DeserializeObject<decimal>(response.Content);




            return Balance;

        }

        public static List<Customers> GetCustomers()
        {
            var client = new RestClient();
            var request = new RestRequest("http://10.0.60.46:5223/api/Customers", Method.Get);
            var response = client.Execute(request);
            List<Customers> CustomerList = JsonConvert.DeserializeObject<List<Customers>>(response.Content);

            return CustomerList;
        }





    }
}
