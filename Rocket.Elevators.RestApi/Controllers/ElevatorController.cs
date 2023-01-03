using Microsoft.AspNetCore.Mvc;
using Rocket.Elevators.RestApi.Infra.Context;
using Rocket.Elevators.RestApi.Model;

namespace Rocket.Elevators.RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ElevatorController : ControllerBase
    {
        private readonly FluentMySqlContext _mySqlContext;

        public ElevatorController(FluentMySqlContext context)
        {
            _mySqlContext = context;
        }

        // https://localhost:7047/api/Elevator/GetElevatorStatusById
        [HttpGet]
        public string GetElevatorStatusById(long id)
        {
            var status = _mySqlContext.Elevators.Where(i => i.Id.Equals(id)).Select(x => x.Status)?.FirstOrDefault();

            return String.IsNullOrEmpty(status) ? "" : status;
        }

      // https://localhost:7047/api/Elevator/UpdateStatusElevatorById
        [HttpPost]
        public void UpdateStatusElevatorById(long id, string status)
        {
            var elevator = _mySqlContext.Elevators.Single(i => i.Id.Equals(id));

            if (elevator is not null && !string.IsNullOrEmpty(status))
            {
                elevator.Status = status;
                _mySqlContext.SaveChanges();
            }
        }
        // https://localhost:7047/api/Elevator/GetAllElevatorStatusNotOperation
        [HttpGet]
        public IEnumerable<Elevator> GetAllElevatorStatusNotOperation()
        {
            return _mySqlContext.Elevators.Where(i => !i.Status.Equals("online"));
        }

    }
}
