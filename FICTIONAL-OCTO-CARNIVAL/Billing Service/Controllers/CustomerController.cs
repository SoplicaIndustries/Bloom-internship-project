using DbAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace Billing_Service.Controllers
{
    public class CustomerController_ : Controller
    {

        public static List<Customers> Get()
        {
            var client = new RestClient("http://localhost:5026/api/Pracownik");
            var request = new RestRequest("");
            var response = client.Execute(request);
            List<Customers> CustomersList = JsonConvert.DeserializeObject<List<Customers>>(response.Content);




            return CustomersList;
        }

        public static void Post(int Deposit)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5026/api/Pracownik/",Method.Post);

            string ToSend = JsonConvert.SerializeObject(Deposit);

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", ToSend, ParameterType.RequestBody);
            var response = client.Execute(request);
    

        }

    }
}
