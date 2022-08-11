
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
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5223/api/Discounts", Method.Get);
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
            var request = new RestRequest("http://localhost:5223/api/Discounts", Method.Get);
            var response = client.Execute(request);
            List<Discounts> DiscountList = JsonConvert.DeserializeObject<List<Discounts>>(response.Content);
            List<Discounts> filteredList = DiscountList.FindAll(c => c.Customer_Id == Id);
            return DataSourceLoader.Load(filteredList, options);
        }
    }
}