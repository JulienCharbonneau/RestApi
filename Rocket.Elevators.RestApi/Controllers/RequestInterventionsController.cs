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

        // GET: api/RequestInterventions
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<RequestIntervention>>> GetRequestInterventions()
        // {
        //     return await _context.RequestInterventions.ToListAsync();
        // }

         [HttpGet]
        public string GetRequestInterventionStatusById(long id)
        {

            var status = _context.RequestInterventions.Where(i => i.Id.Equals(id)).Select(x => x.status)?.FirstOrDefault();

            return String.IsNullOrEmpty(status) ? "" : status;

        }

        // Get request intervention not pending
           [HttpGet]
        public IEnumerable<RequestIntervention> GetAllInterventionNotPending()
        {
            return _context.RequestInterventions.Where(i => !i.status.Equals("Pending"));
        }

        // GET: api/RequestInterventions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestIntervention>> GetRequestIntervention(long id)
        {
            var requestIntervention = await _context.RequestInterventions.FindAsync(id);

            if (requestIntervention == null)
            {
                return NotFound();
            }

            return requestIntervention;
        }

        // PUT: api/RequestInterventions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestIntervention(long id, RequestIntervention requestIntervention)
        {
            if (id != requestIntervention.Id)
            {
                return BadRequest();
            }

            _context.Entry(requestIntervention).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestInterventionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RequestInterventions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RequestIntervention>> PostRequestIntervention(RequestIntervention requestIntervention)
        {
            _context.RequestInterventions.Add(requestIntervention);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestIntervention", new { id = requestIntervention.Id }, requestIntervention);
        }

        // DELETE: api/RequestInterventions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestIntervention(long id)
        {
            var requestIntervention = await _context.RequestInterventions.FindAsync(id);
            if (requestIntervention == null)
            {
                return NotFound();
            }

            _context.RequestInterventions.Remove(requestIntervention);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestInterventionExists(long id)
        {
            return _context.RequestInterventions.Any(e => e.Id == id);
        }
    }
}
