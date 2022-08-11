using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using WebPanel.Models;
namespace WebPanel.Controllers
{
    public class ProductController : Controller
    {



        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5223/api/Products", Method.Get);
            var response = client.Execute(request);
            IEnumerable<Products> ProductsList = JsonConvert.DeserializeObject<IEnumerable<Products>>(response.Content);


            return DataSourceLoader.Load(ProductsList, loadOptions);
        }





        [HttpPost]
        public IActionResult Post(string values)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5223/api/Products/", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", values, ParameterType.RequestBody);
            var response = client.Execute(request);
            return Ok();
        }

        [HttpPut]

        public IActionResult Put(Guid key, string values)
        {




            if (values != String.Empty)
            {
                var client = new RestClient();
                var request = new RestRequest("http://localhost:5223/api/Products", Method.Get);
                var response = client.Execute(request);
                IEnumerable<Products> ProductsList = JsonConvert.DeserializeObject<IEnumerable<Products>>(response.Content);


                var ToUpdate = ProductsList.FirstOrDefault(w => w.Id == key);

                JsonConvert.PopulateObject(values, ToUpdate);




                request = new RestRequest($"http://localhost:5223/api/Products/{key}", Method.Put);
                request.AddHeader("Content-Type", "application/json");
                string body = Newtonsoft.Json.JsonConvert.SerializeObject(ToUpdate);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                response = client.Execute(request);




                return Ok();
            }
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid key)
        {
            var client = new RestClient();
            var request = new RestRequest($"http://localhost:5223/api/Products/{key}", Method.Delete);
            var response = client.Execute(request);
            return Ok();

        }









    }
}
