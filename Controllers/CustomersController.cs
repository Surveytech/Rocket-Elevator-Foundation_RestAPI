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

    public class CustomersController : ControllerBase
    {
        private readonly cslContext _context;

        public CustomersController(cslContext context)
        {
            _context = context;
        }

        //Action that gives the list of all customer
        // GET: api/customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> Getcustomers()
        {
            return await _context.Customers.ToListAsync();
        }

         // Action that recuperates a given customers
        // GET: api/customers/id
        [HttpGet("{email}")]
        public async Task<ActionResult<List<Customers>>> GetcustomersById(string email)
        {
            var customer = await _context.Customers.Where(c => c.CpyContactEmail == email).ToListAsync();

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }
      

        private bool customersExists(long id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
     }
}