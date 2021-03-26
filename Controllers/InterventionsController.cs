using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BuildingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class interventionsController : ControllerBase
    {
        private readonly cslContext _context;

        public interventionsController(cslContext context)
        {
            _context = context;
        }

        //Action that gives the list of all interventions
        // GET: api/interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interventions>>> Getinterventions()
        {
            return await _context.Interventions.ToListAsync();
        }

         // Action that recuperates a given interventions
        // GET: api/interventions/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Interventions>> GetInterventionsById(long id)
        {
            var inter = await _context.Interventions.FindAsync(id);

            if (inter == null)
            {
                return NotFound();
            }

            return inter;
        }
        
        //Action that gives the list of inactive interventions
        //GET : api/interventions/getpendinginterventions
        [HttpGet("getpendinginterventions")]
        public async Task<ActionResult<IEnumerable<Interventions>>> GetPendingInterventions()
        {
            var pending = await (from inter in _context.Interventions
                where inter.InterventionStart == null && inter.Status == "Pending"
                select inter ).ToListAsync();
                

            if (pending == null || !pending.Any())
            {
                return NotFound();
            }

            return pending;
        }
       
        // //retrieval of a column status
        // [HttpGet("{id}/status")]
        // public async Task<ActionResult<string>> GetcolumnStatus(long id)
        // {
        //     var columns = await _context.Columns.FindAsync(id);

        //     if (columns == null)
        //     {
        //         return NotFound();
        //     }

        //     return columns.Status;
            
        // }

        //function called when updating a intervention status to InProgress and start date
        // PUT: using the the id to identify the intervention and the string which will be the new status        
        [HttpPut("{id}/updatestatusdatestart")]
        public async Task<IActionResult> PutmodifyInterventionStatusWithDateStart(long id)
        {
            var intervention = await _context.Interventions.FindAsync(id);

            intervention.Status = "InProgress";
            DateTime starttime = DateTime.Now;
            intervention.InterventionStart = starttime;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!interventionsExists(id))
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
       //function called when updating a intervention status to completed and a end date
        // PUT: using the the id to identify the intervention and the string which will be the new status        
        [HttpPut("{id}/updatestatusdateend")]
        public async Task<IActionResult> PutmodifyInteventionStatusWithDateEnd(long id)
        {
            var intervention = await _context.Interventions.FindAsync(id);

            intervention.Status = "Completed";
            DateTime endtime = DateTime.Now;
            intervention.InterventionEnd = endtime;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!interventionsExists(id))
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



        private bool interventionsExists(long id)
        {
            return _context.Interventions.Any(e => e.Id == id);
        }
     }
}