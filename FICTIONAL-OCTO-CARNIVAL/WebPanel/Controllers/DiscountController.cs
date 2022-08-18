
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using WebPanel.Models;

namespace WebPanel.Controllers
{
    public class DiscountController : Controller
    {
        public static decimal DiscountCalculus(decimal price,decimal discount)
        {
            decimal ToSend = (price * (price*discount))/100;


            return ToSend;
        }




        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var client = new RestClient();
            var request = new RestRequest("http://10.0.60.46:5223/api/Discounts", Method.Get);
            var response = client.Execute(request);
            List<Discounts> DiscountList = JsonConvert.DeserializeObject<List<Discounts>>(response.Content);
            List<UnitsOfUsage> UnitList = UnitOfUsageController.GetUnits();

            foreach (Discounts discount in DiscountList)
            {
                UnitsOfUsage unit;
                unit = UnitList.Find(c => c.Id == discount.UnitOfUsageId);
                discount.UnitOfUsage = unit.Name;

            }

            return DataSourceLoader.Load(DiscountList, loadOptions);
        }

        [HttpGet]
        public object GetDiscountsById(Guid Id, DataSourceLoadOptions options)
        {
            var client = new RestClient();
            var request = new RestRequest("http://10.0.60.46:5223/api/Discounts", Method.Get);
            var response = client.Execute(request);
            List<Discounts> DiscountList = JsonConvert.DeserializeObject<List<Discounts>>(response.Content);
            List<Discounts> filteredList = DiscountList.FindAll(c => c.Customer_Id == Id);
            foreach(Discounts discount in filteredList)
            {
                discount.Discount_Percentage = discount.Discount_Percentage/100;
                discount.Customer_Price = discount.Price - (discount.Price * discount.Discount_Percentage);
                 
            }
            return DataSourceLoader.Load(filteredList, options);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var client = new RestClient();
            var dis = JsonConvert.DeserializeObject<Discounts>(values);
            dis.Id = 0;
           
            values = JsonConvert.SerializeObject(dis);
            var request = new RestRequest("http://10.0.60.46:5223/api/Discounts/", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", values, ParameterType.RequestBody);
            var response = client.Execute(request);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int key)
        {
            var client = new RestClient();
            var request = new RestRequest($"http://10.0.60.46:5223/api/Discounts/{key}", Method.Delete);
            var response = client.Execute(request);
            return Ok();

        }

    }
}