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
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomer()
        {
            return await _context.Customers.ToListAsync();
        }

         // Action that recuperates a given customers
        // GET: api/customers/id
        [HttpGet("{Email}")]
        public async Task<ActionResult<List<Customers>>> GetCustomerbyEmail(string Email)
        {
            var customer = await _context.Customers.Where(c => c.CpyContactEmail == Email).ToListAsync();

            if (!CustomerExists(Email))
            {
                return BadRequest();
            }

            return customer;
        }
      

        private bool CustomerExists(string Email)
        {
            return _context.Customers.Any(c => c.CpyContactEmail == Email);
        }
     }
}