using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using WebPanel.Models;

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
            Guid guid = new Guid("3fa85f62-5717-4562-b3fc-2c963f66afa6");
            List<Transactions> Klar = TransactionsList.FindAll(c => c.Customer_Id == guid);


            return DataSourceLoader.Load(Klar, loadOptions);
        }


        [HttpGet]
        public object GetTransactionById(Guid Id, DataSourceLoadOptions options)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5223/api/Transactions", Method.Get);
            var response = client.Execute(request);
            List<Transactions> TransactionsList = JsonConvert.DeserializeObject<List<Transactions>>(response.Content);
            List<Transactions> filteredList = TransactionsList.FindAll(c => c.Customer_Id == Id);
            return DataSourceLoader.Load(filteredList, options);
        }

        public void PostBalance(decimal deposit)
        {
            Guid guid = new Guid("3fa85f62-5717-4562-b3fc-2c963f66afa6");
            Customers customer;
            List<Customers> ListCustomers = CustomerController.GetCustomers();
            decimal Balance = CustomerController.GetBalance(guid);

            Transactions trans = new Transactions();
            trans.Currency_Id = 1;
            trans.Product_Id = new Guid("9d7bda08-65ba-41a2-882d-6423b568b584");
            trans.Description = "Money deposit: " + deposit + " zł";
            trans.Customer_Id = guid;
            trans.Price = deposit;
            trans.Reference_Number = Guid.NewGuid();
            trans.Balance_After = Balance + deposit;
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5223/api/Transactions", Method.Post);


            string ToSend = JsonConvert.SerializeObject(trans);

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", ToSend, ParameterType.RequestBody);
            var response = client.Execute(request);

        }
    }

    }

