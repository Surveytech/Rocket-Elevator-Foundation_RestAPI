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
        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployee()
        {
            return await _context.Employees.ToListAsync();
        }

         // Action that recuperates a given employee
        // GET: api/employee/id
        [HttpGet("{Email}")]
        public async Task<ActionResult<List<Employees>>> GetEmployeebyEmail(string logEmail)
        {
            var employee = await _context.Employees.Where(e => e.Email == logEmail).ToListAsync();

            if (!EmployeeExists(logEmail))
            {
                return BadRequest();
            }

            return employee;
        }
      

        private bool EmployeeExists(string logEmail)
        {
            return _context.Employees.Any(e => e.Email == logEmail);
        }
     }
}