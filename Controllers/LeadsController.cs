using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using BuildingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuildingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeadsController : ControllerBase
    {
        private readonly MaximeAuger_mysqlContext _context;

        public LeadsController(MaximeAuger_mysqlContext context)
        {
            _context = context;
        }

        // GET: api/leads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leads>>> Getleads()
        {

            return await _context.Leads.ToListAsync();
        }


        // Action that recuperates a given Leads
        // GET: api/leads/id
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Leads>> GetleadsId(long Id)
        // {
        //     var leads = await _context.Leads.FindAsync(Id);

        //     if (leads == null)
        //     {
        //         return NotFound();
        //     }

        //     return leads;
        // }

        
        // Action that recuperates a given Leads
        // GET: api/leads/leadsNoCustomer}
        [HttpGet("{leadsNoCustomer}")]
        public async Task<ActionResult<List<Leads>>> GetleadsCustomers()
        {
            var leads = await _context.Leads.Where(l => l.customers_id == null).ToListAsync();
            var newLeads = leads.Where(e => e.created_at >= DateTime.Today.AddDays(-30)).ToList();

            if (newLeads == null)
            {
                return NotFound();
            }

            return newLeads;
        }
    }
}

