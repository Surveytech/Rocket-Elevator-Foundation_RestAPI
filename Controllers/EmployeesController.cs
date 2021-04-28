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

    public class EmployeesController : ControllerBase
    {
        private readonly cslContext _context;

        public EmployeesController(cslContext context)
        {
            _context = context;
        }

        //Action that gives the list of all customer
        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployee()
        {
            return await _context.Employees.ToListAsync();
        }

         // Action that recuperates a given employee
        // GET: api/Employees/Email
        [HttpGet("{Email}")]
        public async Task<ActionResult<List<Employees>>> GetEmployeesbyEmail(string Email)
        {
            var employee = await _context.Employees.Where(c => c.Email == Email).ToListAsync();

            if (!EmployeeExists(Email))
            {
                return BadRequest();
            }

            return employee;
        }
      

        private bool EmployeeExists(string Email)
        {
            return _context.Employees.Any(c => c.Email == Email);
        }
     }
}