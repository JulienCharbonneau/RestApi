using System.Data;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Rocket.Elevators.RestApi.Infra.Context;
using Rocket.Elevators.RestApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace Rocket.Elevators.RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly FluentMySqlContext _mySqlContext;
        private string customer_email_is_on_database;

        public CustomerController(FluentMySqlContext context)
        {
            _mySqlContext = context;
        }

        // https://localhost:7047/api/Customer/GetAuthenticationCustomerByEmail
        [HttpGet]
        public string GetAuthenticationCustomerByEmail(string input_email)
        {
            string customer_is_on_database = null;


            var customer_id = _mySqlContext.Customers.Where(c => c.ContactEmail == input_email).Select(x => x.Id)?.FirstOrDefault();
            Console.WriteLine("test: " + customer_id);
                if (customer_id != 0 ) {
                    customer_is_on_database = "true";
                }
                else {
                    customer_is_on_database = "false";

                }
    
            return  customer_is_on_database;

        }


 // https://localhost:7047/api/Customer/GetCustomerIdByEmail
        [HttpGet]
        public long GetCustomerIdByEmail(string input_email)
        {



            var customer_id = _mySqlContext.Customers.Where(c => c.ContactEmail == input_email).Select(x => x.Id)?.FirstOrDefault();

            Console.WriteLine("test: " + customer_id);
             
    
            return (long)customer_id;

        }

       

     

     

    }
}
