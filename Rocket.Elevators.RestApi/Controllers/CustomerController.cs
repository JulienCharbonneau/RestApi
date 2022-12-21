using System.Data;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Rocket.Elevators.RestApi.Infra.Context;
using Rocket.Elevators.RestApi.Model;

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

        // GET: Select
        [HttpGet]
        public string GetCustomerByEmail(string input_email)
        {
            var customer_is_on_database = "";
            var customer = _mySqlContext.Customers.Where(c => c.ContactEmail == input_email);

                if (customer.IsNullOrEmpty() ) {
                    customer_is_on_database = "true";
                }
                else {
                    customer_is_on_database = "false";

                }

            return  customer_is_on_database;

        }

       
     

     

    }
}
