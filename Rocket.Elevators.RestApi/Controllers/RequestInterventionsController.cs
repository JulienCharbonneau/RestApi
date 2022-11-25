using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket.Elevators.RestApi.Infra.Context;
using Rocket.Elevators.RestApi.Model;

namespace Rocket.Elevators.RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RequestInterventionsController : ControllerBase
    {
        private readonly FluentMySqlContext _context;

        public RequestInterventionsController(FluentMySqlContext context)
        {
            _context = context;
        }


        // Get request intervention not pending
           [HttpGet]
        public IEnumerable<RequestIntervention> GetAllInterventionNotPending()
        {
            return _context.RequestInterventions.Where(i => !i.status.Equals("Pending"));
        }

       

        // PUT: api/RequestInterventions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
          public void UpdateStatusRequestInterventionInProgress(long id)
        {
            var requestIntervention = _context.RequestInterventions.Single(i => i.Id.Equals(id));

            if (requestIntervention is not null)
            {
                requestIntervention.status = "InProgress";
                DateTime now = DateTime.Now;
                requestIntervention.start_date = now.ToString("F");
                _context.SaveChanges();
            }
        }


         [HttpPut]
          public void UpdateStatusRequestInterventionCompleted(long id)
        {
            var requestIntervention = _context.RequestInterventions.Single(i => i.Id.Equals(id));

            if (requestIntervention is not null)
            {
                requestIntervention.status = "Completed";
                requestIntervention.result = "completed";
                DateTime now = DateTime.Now;
                requestIntervention.end_date = now.ToString("F");
                _context.SaveChanges();
            }
        }

       

    }
}
