using Microsoft.AspNetCore.Mvc;
using Rocket.Elevators.RestApi.Infra.Context;
using Rocket.Elevators.RestApi.Model;

namespace Rocket.Elevators.RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LeadController : ControllerBase
    {
        private readonly FluentMySqlContext _mySqlContext;

        public LeadController(FluentMySqlContext context)
        {
            _mySqlContext = context;
        }
        
        [HttpGet]
        public IEnumerable<Lead> GetAllLeads()
        {
            return _mySqlContext.Leads;
        }

        [HttpGet]
        public Lead GetLeadById(long id)
        {
            return _mySqlContext.Leads.Single(i => i.Id.Equals(id));
        }

        [HttpGet]
        public IEnumerable<Lead> GetAllLeadsCreatedLast30DaysNotYetCustomer()
        {
            List<Lead> listLeads = new List<Lead>();
            var end = DateTime.Now.Date;
            var start = end.AddDays(-30);
            var leads = _mySqlContext.Leads.Where(d => d.CreatedAt >= start && d.CreatedAt < end).ToList();
            var customersEmails = _mySqlContext.Customers.Select(e => e.Email).ToList();

            foreach (var lead in leads)
            {
                if (customersEmails.Contains(lead.Email))
                    listLeads.Add(lead);
            }

            return listLeads;
        }
    }
}
