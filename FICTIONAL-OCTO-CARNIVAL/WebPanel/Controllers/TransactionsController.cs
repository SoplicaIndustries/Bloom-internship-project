using WebPanel.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace WebPanel.Controllers
{
    public class TransactionsController : Controller
    {

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5223/api/Transactions", Method.Get);
            var response = client.Execute(request);
            List<Transactions> TransactionsList = JsonConvert.DeserializeObject<List<Transactions>>(response.Content);
            List<Customers> CustomerList = CustomerController.GetCustomers();

            foreach(Transactions trasaction in TransactionsList)
            {
                Transactions trans;
                Customers customer;
                customer = CustomerList.Find(c => c.Id == trasaction.Customer_Id);
                



            }


            return DataSourceLoader.Load(TransactionsList, loadOptions);
        }

    }
    
}
