using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuildingApi.Models;

namespace BuildingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class elevatorsController : ControllerBase
    {
        private readonly MaximeAuger_mysqlContext _context;

        public elevatorsController(MaximeAuger_mysqlContext context)
        {
            _context = context;
        }

        // GET: api/elevators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elevators>>> Getelevators()
        {
            return await _context.Elevators.ToListAsync();
        }

         // Action that recuperates a given elevators by Id 
        // GET: api/elevators/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevators>> GetelevatorsById(long id)
        {
            var elevators = await _context.Elevators.FindAsync(id);

            if (elevators == null)
            {
                return NotFound();
            }

            return elevators;
        }

       
        //Action that recuperates the status of a given elevator
        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetelevatorStatus(long id)
        {
            var elevator = await _context.Elevators.FindAsync(id);

            if (elevator == null)
            {
                return NotFound();
            }

            return elevator.Status;
        }


        //Action that gives the list of inactive elevators
        //GET : api/elevators/inactiveelevators
        [HttpGet("inactiveelevators")]
        public async Task<ActionResult<List<Elevators>>> GetinactiveElevators()
        {
            var elevator = await _context.Elevators
                .Where(c => c.Status != "Online").ToListAsync();
                

            if (elevator == null)
            {
                return NotFound();
            }

            return elevator;
        }


       
        //Updating the status of a given elevator. Frist, identification of the elevator is needed.
        // PUT: api/elevators/id/updatestatus        
        [HttpPut("{id}/updatestatus")]
        public async Task<IActionResult> PutmodifyElevatorStatus(long id, string status)
        {
            if (status == null)
            {
                return BadRequest();
            }

            var elevator = await _context.Elevators.FindAsync(id);

            elevator.Status = status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!elevatorsExists(id))
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

        private bool elevatorsExists(long id)
        {
            return _context.Elevators.Any(e => e.Id == id);
        }
    }
}
