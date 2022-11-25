using Microsoft.AspNetCore.Mvc;
using Rocket.Elevators.RestApi.Infra.Context;
using Rocket.Elevators.RestApi.Model;

namespace Rocket.Elevators.RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BatteryController : ControllerBase
    {
        private readonly FluentMySqlContext _mySqlContext;

        public BatteryController(FluentMySqlContext context)
        {
            _mySqlContext = context;
        }
        
        
        [HttpGet]
        public string GetBatteryStatusById(long id)
        {
            var status = _mySqlContext.Batteries.Where(i => i.Id.Equals(id)).Select(x => x.Status).FirstOrDefault();

            return String.IsNullOrEmpty(status) ? "" : status;
        }

        [HttpPost]
        public void UpdateStatusBatteryById(long id, string status)
        {
            var battery = _mySqlContext.Batteries.Single(i => i.Id.Equals(id));

            if (battery is not null && !string.IsNullOrEmpty(status))
            {
                battery.Status = status;
                _mySqlContext.SaveChanges();
            }
        }
    }
}
