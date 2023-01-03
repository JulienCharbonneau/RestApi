using Microsoft.AspNetCore.Mvc;
using Rocket.Elevators.RestApi.Infra.Context;



namespace Rocket.Elevators.RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
       private readonly FluentMySqlContext _mySqlContext;

        public EmployeeController(FluentMySqlContext context)
        {
            _mySqlContext = context;
        }


        // https://localhost:7047/api/Employee/CheckEmail
        [HttpGet]
        public bool CheckEmail(string email)
        {
            // use Entity Framework to check if the email exists in the database
            bool emailExists = _mySqlContext.Employees.Any(e => e.Email == email);

            // return true if the email exists, false if it does not
            return emailExists;
        }
    }
}
