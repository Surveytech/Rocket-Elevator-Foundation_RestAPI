using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingApi.Models;
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

       
        //retrieval of a column status
        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetcolumnStatus(long id)
        {
            var columns = await _context.Columns.FindAsync(id);

            if (columns == null)
            {
                return NotFound();
            }

            return columns.Status;
            
        }

        
        //function called when updating a column status
        // PUT: using the the id to identify the column and the string which will be the new status        
        [HttpPut("{id}/updatestatus")]
        public async Task<IActionResult> PutmodifyColumnStatus(long id, string Status)
        {
            if (Status == null)
            {
                return BadRequest();
            }

            var column = await _context.Columns.FindAsync(id);

            column.Status = Status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!columnsExists(id))
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

        private bool columnsExists(long id)
        {
            return _context.Columns.Any(e => e.Id == id);
        }
    }
}