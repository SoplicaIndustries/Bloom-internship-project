using DbAPI.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace Billing_Service.Controllers
{
    public class ProductController : Controller
    {

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5223/api/Products", Method.Get);
            var response = client.Execute(request);
            List<Products> ProductsList = JsonConvert.DeserializeObject<List<Products>>(response.Content);
            List<UnitsOfUsage> Units = UnitOfUsageController.Get();

            foreach(Products Product in ProductsList)
            {
                UnitsOfUsage Unit;
                Unit = Units.Find(c => c.Id == Product.UnitOfUsageId);
                Product.UnitOfUsage = Unit.Name;

            }





            return DataSourceLoader.Load(ProductsList, loadOptions);
        }




        public static void Post(Products product)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5223/api/Products/", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", product, ParameterType.RequestBody);
            var response = client.Execute(request);
        }

        public static void Put(Products product)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5223/api/Products/", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", product, ParameterType.RequestBody);
            var response = client.Execute(request);
        }

        public static void Delete(int Id)
        {
            var client = new RestClient();
            var request = new RestRequest($"http://localhost:5223/api/Products/{Id}", Method.Delete);
            var response = client.Execute(request);


        }








    }
}
