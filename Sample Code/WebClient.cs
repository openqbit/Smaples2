using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using IJSE.PosClient.Presentation.Web.Models;
using System.Web.Script.Serialization;
using System.Threading.Tasks;

namespace IJSE.PosClient.Presentation.Web.WebApi
{
    public class WebClient
    {
        HttpClient _client;
        JavaScriptSerializer _jsonSerializer = new JavaScriptSerializer();

        public WebClient()
        {
            _client = new HttpClient();
        }

        public async Task<Customer> GetCustomer()
        {
            Customer customer = new Customer();

            using (var response = await _client.GetAsync("http://localhost:51279/api/Customer/1"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    customer = _jsonSerializer.Deserialize<Customer>(jsonString);
                }
            }


            return customer;

        }


        public async Task<bool> AddCustomer(Customer newCustomer)
        {
            

            var webServiceData = new MultipartFormDataContent();

            webServiceData.Add(new StringContent(_jsonSerializer.Serialize(newCustomer)), "newCustomer");


            // string json = _jsonSerializer.Serialize(customer);

            using (var response = await _client.PostAsync("http://localhost:51279/api/AddCustomer/", webServiceData)) 
            {
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                   // customer = _jsonSerializer.Deserialize<Customer>(jsonString);
                }
            }


            return true;

        }

    }
}