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
    public class BuildingController : ControllerBase

    {
        private readonly cslContext _context;

        public BuildingController(cslContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buildings>>> Getbuildings()
        {
            return await _context.Buildings.ToListAsync();
        }
        
        // Action that gives the list of buildings
        // GET: api/building/listofbuildings
        [HttpGet("listofbuildings")]
        public async Task<ActionResult<IEnumerable<Buildings>>> GetbuildingList()
        {
         
            
             var building = await (from cust in _context.Buildings
                            join bat in _context.Batteries on cust.Id equals bat.BuildingId
                            join col in _context.Columns on bat.Id equals col.BatteryId
                            join ele in _context.Elevators on col.Id equals ele.ColumnId
                            where ele.Status == "Offline" || col.Status == "Offline" || bat.Status == "Offline"
                            select cust).Distinct().ToListAsync();
                  
            if (building == null)
            {
                return NotFound();
            }

            return building;
        }
        // GET: api/building/listofbuildings
        [HttpGet("CustomerId/{customersId}")]
        public async Task<ActionResult<List<Buildings>>> GetbuildingByCustomerId(long customersId)
        {
            var buildings = await _context.Buildings.Where(c => c.CustomerId == customersId).ToListAsync();
            if (buildings == null)
            {
                return NotFound();
            }
            return buildings;
        }
    }

}