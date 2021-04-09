using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using BuildingApi.Model;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;

namespace BuildingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BatteriesController : ControllerBase
    {
        private readonly cslContext _context;

        public BatteriesController(cslContext context)
        {
            _context = context;
        }

        // GET: api/batteries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batteries>>> Getbatteries()
        {
            return await _context.Batteries.ToListAsync();
        }


        // Action that recuperates a given battery
        // GET: api/batteries/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Batteries>> Getbatteries(long Id)
        {
            var bat = await _context.Batteries.FindAsync(Id);

            if (bat == null)
            {
                return NotFound();
            }

            return bat;
        }
        
        // Action that recuperate the status of a given battery
        // GET batterystatus: 
        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetbatteryStatus(long Id)
        {
            var bat = await _context.Batteries.FindAsync(Id);

            if (bat == null)
            {
                return NotFound();
            }

            return bat.Status;

        }
        //Modification of Battery status. First, identification of a given battery is needed. 
         // PUT: api/batteries/id/updatestatus
        [HttpPut("{id}/updatestatus")]
        public async Task<IActionResult> PutmodifBatterySatus(long Id, string Status)
        {
                       
            if (Status == null)
            {
                return BadRequest();
            }

            var battery = await _context.Batteries.FindAsync(Id);
            battery.Status = Status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteriesExists(Id))
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
        [HttpGet("buildingId/{buildingId}")]
        public async Task<ActionResult<IEnumerable<Batteries>>> GetbatteriesBybuildingId(long buildingId)
        {
            var batteries = await _context.Batteries.Where(c => c.BuildingId == buildingId).ToListAsync();

            if (batteries == null)
            {
                return NotFound();
            }

            return batteries;
        }

        private bool BatteriesExists(long id)
        {
            return _context.Batteries.Any(e => e.Id == id);
        }
    }
}