using Microsoft.AspNetCore.Mvc;
using Rocket.Elevators.RestApi.Infra.Context;

namespace Rocket.Elevators.RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ColumnController : ControllerBase
    {
        private readonly FluentMySqlContext _mySqlContext;

        public ColumnController(FluentMySqlContext context)
        {
            _mySqlContext = context;
        }
        
        [HttpGet]
        public string GetColumnStatusById(long id)
        {

            var status = _mySqlContext.Columns.Where(i => i.Id.Equals(id)).Select(x => x.Status)?.FirstOrDefault();

            return String.IsNullOrEmpty(status) ? "" : status;

        }

        [HttpPost]
        public void UpdateStatusColumnById(long id, string status)
        {
            var column = _mySqlContext.Columns.Single(i => i.Id.Equals(id));
         
        

            if (column is not null && !string.IsNullOrEmpty(status))
            {
                column.Status = status;
                _mySqlContext.SaveChanges();
            }
        }
    }
}
