using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Threading.Tasks;
using IJSE.PosClient.Presentation.Web.WebApi;
using IJSE.PosClient.Presentation.Web.Models;

namespace IJSE.PosClient.Presentation.Web.Controllers
{
    public class CustomerController : Controller
    {
        //public async Task<ActionResult> Index()
        //{
        //    WebClient client = new WebClient();
        //    Customer customer = await client.GetCustomer();

        //    return View(customer);
        //}

        public async Task<ActionResult> Index()
        {
            WebClient client = new WebClient();
            Customer customer = new Customer { ID = 45, Name = "ClientCustomer", Address = "No25", Creditlimit = 25000, Tel = "0112" };

            await client.AddCustomer(customer);

            return View(customer);
        }


    }
}